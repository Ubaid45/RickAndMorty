using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models.Characters;

namespace RickAndMorty.API.Controllers;

[Route("api/[action]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
    {
        _logger = logger;
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCharacters(CancellationToken ct)
    {
        _logger.LogInformation("Getting all the characters");
        var characters = await _characterService.GetAllEntities(ct);
        return Ok(characters);
    }

    [HttpGet]
    public async Task<IActionResult> GetASingleCharacter(int id, CancellationToken ct)
    {
        _logger.LogInformation("Getting a single characters");
        var character = await _characterService.GetASingleEntity(id, ct);
        return Ok(character);
    }

    [HttpGet]
    public async Task<IActionResult> GetMultipleCharacters([FromQuery] int[] ids, CancellationToken ct)
    {
        _logger.LogInformation("Getting the multiple characters");
        var multipleCharacters = await _characterService.GetMultipleEntities(ids, ct);
        return Ok(multipleCharacters);
    }
    
    [HttpGet]
    public async Task<IActionResult> FilterCharacters(CancellationToken ct)
    {
        IQueryCollection queryParams = HttpContext.Request.Query;
        _logger.LogInformation("Filter the characters");
        var filterCharacters = await _characterService.FilterEntities(queryParams, ct);
        return Ok(filterCharacters);
    }
}