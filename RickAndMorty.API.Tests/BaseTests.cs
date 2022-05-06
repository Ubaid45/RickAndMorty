using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Abstraction.Models.Episodes;
using RickAndMorty.Application.Abstraction.Models.Locations;
using RickAndMorty.Application.Common;
using RickAndMorty.Data.Abstraction;

namespace RickAndMorty.API.Tests
{
    /// <summary>
    /// Basic setup for the unit tests
    /// </summary>
    internal class BaseTests
    {
        protected Mock<IHttpRequestHandler> HttpRequestHandlerMock;
        protected IMapper Mapper;
        protected ServiceResponse<List<Character>> CharacterApiResponse;
        protected ServiceResponse<List<Location>> LocationApiResponse;
        protected ServiceResponse<List<Episode>> EpisodeApiResponse;
        protected const int CollectionCount = 5;

        [SetUp]
        protected async Task BaseSetUp()
        {
            // Arrange
            HttpRequestHandlerMock = new Mock<IHttpRequestHandler>();
            
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            
            Mapper = mapperConfiguration.CreateMapper();
            
            CharacterApiResponse = await PopulateCharacters();
            LocationApiResponse = await PopulateLocations();
            EpisodeApiResponse = await PopulateEpisodes();
        }
        
        [TearDown]
        protected void BaseTearDown() { /* ... */ }

        #region Private Methods 
        
        private async Task<ServiceResponse<List<Character>>> PopulateCharacters()
        {
            return await PopulateResponse<Character>("characters");
        }
        
        private async Task<ServiceResponse<List<Episode>>> PopulateEpisodes()
        {
            return await PopulateResponse<Episode>("episodes");
        }
        
        private async Task<ServiceResponse<List<Location>>> PopulateLocations()
        {
            return await PopulateResponse<Location>("locations");
        }
        private async Task<ServiceResponse<List<T>>> PopulateResponse<T>(string fileName) where T : class
        {
            // TODO
            var directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            using var r = new StreamReader(Path.Combine(directory ?? string.Empty,$"{fileName}.json"));
            var json =  await r.ReadToEndAsync();
            var response = JsonConvert.DeserializeObject<ServiceResponse<List<T>>>(json);
            return response;
        }
        
        #endregion
        
    }
}