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
using RickAndMorty.Application.Abstraction.Models.Locations;
using RickAndMorty.Application.Common;
using RickAndMorty.Application.Services;

namespace RickAndMorty.API.Tests;

[TestFixture]
internal class LocationTests : BaseTests
{
    [Test]
    public async Task GetAllLocations_WhenRequested_ShouldReturnAllLocations()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Location>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(LocationApiResponse);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await locationService.GetAllEntities(It.IsAny<CancellationToken>());

        // Assert
        result.Info.Should().NotBeNull()
            .And.BeOfType<Info>();
            
        result.Results.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Location>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    
    
    [Test]
    public async Task GetASingleLocation_WhenRequestedWithAValidId_ShouldReturnItsLocation()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<Location>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(LocationApiResponse.Results[0]);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await locationService.GetASingleEntity(It.IsAny<int>(),It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull()
            .And.BeOfType<Location>();
    }

    [Test]
    public async Task GetMultipleLocations_WhenRequestedWithValidIds_ShouldReturnMultipleLocations()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<List<Location>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(LocationApiResponse.Results);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await locationService.GetMultipleEntities(It.IsAny<int[]>(),It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Location>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    
    
    [Test]
    public async Task FilterLocations_WhenRequestedWithValidParameters_ShouldReturnFilteredLocations()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Location>>>(string.Empty, It.IsAny<CancellationToken>()))
            .ReturnsAsync(LocationApiResponse);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act
        var result = await locationService.FilterEntities(It.IsAny<IQueryCollection>(),It.IsAny<CancellationToken>());

        // Assert
        result.Info.Should().NotBeNull()
            .And.BeOfType<Info>();
            
        result.Results.Should().NotBeNullOrEmpty()
            .And.ContainItemsAssignableTo<Location>()
            .And.HaveCount(CollectionCount)
            .And.OnlyHaveUniqueItems();
    }
    
    

    # region Exceptions

    [Test]
    public async Task GetAllLocations_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Location?>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ServiceResponse<List<Location?>>?)null);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await locationService.Invoking(y => y.GetAllEntities(It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task GetASingleLocation_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<Location>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Location?)null);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await locationService.Invoking(y => y.GetASingleEntity(It.IsAny<int>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task GetMultipleLocations_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<List<Location>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((List<Location>?)null);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await locationService.Invoking(y => y.GetMultipleEntities(It.IsAny<int[]>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Test]
    public async Task FilterLocations_WhenRequestedButSomeErrorOccured_ShouldReturnBadRequestException()
    {
        // Arrange
        HttpRequestHandlerMock.Setup(m =>
                m.ProcessRequest<ServiceResponse<List<Location>>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ServiceResponse<List<Location>>?)null);
        
        var locationService = new LocationService(HttpRequestHandlerMock.Object, Mapper);

        // Act and Assert
        await locationService.Invoking(y => y.FilterEntities(It.IsAny<IQueryCollection>(),It.IsAny<CancellationToken>()))
            .Should().ThrowAsync<HttpStatusException>().Where(
                m => m.ErrorCode == nameof(ErrorCodes.BadRequestParameters) && m.StatusCode == HttpStatusCode.BadRequest);
    }
    
    #endregion
    
}