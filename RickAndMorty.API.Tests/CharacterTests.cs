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
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Common;
using RickAndMorty.Application.Services;

namespace RickAndMorty.API.Tests;

[TestFixture]
internal class CharacterTests : BaseTests
{
    [Test]
    public async Task GetAllCharacters_WhenRequested_ShouldReturnAllCharacters()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Character>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CharacterApiResponse);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await characterService.GetAllEntities(It.IsAny<CancellationToken>());

        // Assert
        result.Info.Should().NotBeNull()
            .And.BeOfType<Info>();
            
        result.Results.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Character>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    
    
    [Test]
    public async Task GetASingleCharacter_WhenRequestedWithAValidId_ShouldReturnItsCharacter()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<Character>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CharacterApiResponse.Results[0]);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await characterService.GetASingleEntity(It.IsAny<int>(),It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull()
            .And.BeOfType<Character>();
    }

    [Test]
    public async Task GetMultipleCharacters_WhenRequestedWithValidIds_ShouldReturnMultipleCharacters()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<List<Character>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CharacterApiResponse.Results);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await characterService.GetMultipleEntities(It.IsAny<int[]>(),It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Character>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    
    
    [Test]
    public async Task FilterCharacters_WhenRequestedWithValidParameters_ShouldReturnFilteredCharacters()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Character>>>(string.Empty, It.IsAny<CancellationToken>()))
            .ReturnsAsync(CharacterApiResponse);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await characterService.FilterEntities(It.IsAny<IQueryCollection>(),It.IsAny<CancellationToken>());

        // Assert
        result.Info.Should().NotBeNull()
            .And.BeOfType<Info>();
            
        result.Results.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Character>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    

    # region Exceptions

    [Test]
    public async Task GetAllCharacters_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Character?>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ServiceResponse<List<Character?>>?)null);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await characterService.Invoking(y => y.GetAllEntities(It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task GetASingleCharacter_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<Character>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Character?)null);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await characterService.Invoking(y => y.GetASingleEntity(It.IsAny<int>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task GetMultipleCharacters_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<List<Character>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((List<Character>?)null);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await characterService.Invoking(y => y.GetMultipleEntities(It.IsAny<int[]>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task FilterCharacters_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Character>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ServiceResponse<List<Character>>?)null);
        
        var characterService = new CharacterService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await characterService.Invoking(y => y.FilterEntities(It.IsAny<IQueryCollection>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    #endregion
    
}