using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.IServices;

namespace RickAndMorty.API.Controllers;

[Route("api/[action]")]
[ApiController]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;
    private readonly ILogger<LocationController> _logger;
    // GET
    public LocationController(ILocationService locationService, ILogger<LocationController> logger)
    {
        _locationService = locationService;
        _logger = logger;
    }
    
     
    [HttpGet]
    public async Task<IActionResult> GetAllLocations( CancellationToken ct)
    {
        _logger.LogInformation("Getting all the locations");
        var characters = await _locationService.GetAllEntities(ct);
        return Ok(characters);
    }
    
}