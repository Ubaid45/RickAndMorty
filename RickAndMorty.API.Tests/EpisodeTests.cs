using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Episodes;
using RickAndMorty.Application.Common;
using RickAndMorty.Application.Services;

namespace RickAndMorty.API.Tests;

[TestFixture]
internal class EpisodeTests : BaseTests
{
    [Test]
    public async Task GetAllEpisodes_WhenRequested_ShouldReturnAllEpisodes()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Episode>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(EpisodeApiResponse);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await episodeService.GetAllEntities(It.IsAny<CancellationToken>());

        // Assert
        result.Info.Should().NotBeNull()
            .And.BeOfType<Info>();
            
        result.Results.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Episode>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    
    
    [Test]
    public async Task GetASingleEpisode_WhenRequestedWithAValidId_ShouldReturnItsEpisode()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<Episode>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(EpisodeApiResponse.Results[0]);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await episodeService.GetASingleEntity(It.IsAny<int>(),It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull()
            .And.BeOfType<Episode>();
    }

    [Test]
    public async Task GetMultipleEpisodes_WhenRequestedWithValidIds_ShouldReturnMultipleEpisodes()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<List<Episode>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(EpisodeApiResponse.Results);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await episodeService.GetMultipleEntities(It.IsAny<int[]>(),It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Episode>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    
    
    [Test]
    public async Task FilterEpisodes_WhenRequestedWithValidParameters_ShouldReturnFilteredEpisodes()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Episode>>>(string.Empty, It.IsAny<CancellationToken>()))
            .ReturnsAsync(EpisodeApiResponse);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await episodeService.FilterEntities(It.IsAny<IQueryCollection>(),It.IsAny<CancellationToken>());

        // Assert
        result.Info.Should().NotBeNull()
            .And.BeOfType<Info>();
            
        result.Results.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Episode>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    

    # region Exceptions

    [Test]
    public async Task GetAllEpisodes_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Episode?>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ServiceResponse<List<Episode?>>?)null);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await episodeService.Invoking(y => y.GetAllEntities(It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task GetASingleEpisode_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<Episode>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Episode?)null);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await episodeService.Invoking(y => y.GetASingleEntity(It.IsAny<int>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task GetMultipleEpisodes_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<List<Episode>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((List<Episode>?)null);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await episodeService.Invoking(y => y.GetMultipleEntities(It.IsAny<int[]>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task FilterEpisodes_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Episode>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ServiceResponse<List<Episode>>?)null);
        
        var episodeService = new EpisodeService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await episodeService.Invoking(y => y.FilterEntities(It.IsAny<IQueryCollection>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    #endregion
    
}