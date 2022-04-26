using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Net.Api.Models.Enums;

namespace RickAndMorty.API.Controllers;

[Route("api/[action]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IRickAndMortyApi _rickAndMortyApi;
    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ILogger<CharacterController> logger, IRickAndMortyApi rickAndMortyApi)
    {
        _logger = logger;
        _rickAndMortyApi = rickAndMortyApi;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCharacters( CancellationToken ct)
    {
        _logger.LogInformation("Getting all the characters");
        var characters = await _rickAndMortyApi.GetAllCharacters();
        return Ok(characters);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetASingleCharacters(int id)
    {
        _logger.LogInformation("Getting a single characters");
        var character = await _rickAndMortyApi.GetCharacter(id);
        return Ok(character);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMultipleCharacters(int[] ids)
    {
        _logger.LogInformation("Getting the multiple characters");
        var multipleCharacters = await _rickAndMortyApi.GetMultipleCharacters(ids);
        return Ok(multipleCharacters);
    }
    
    [HttpGet]
    public async Task<IActionResult> FilterCharacters( string name,
        CharacterStatus? characterStatus, string species, string type,
        CharacterGender? gender)
    {
        _logger.LogInformation("Filter the characters");
        var filterCharacters = await _rickAndMortyApi.FilterCharacters(name, characterStatus, species, type, gender);
        return Ok(filterCharacters);
    }
}