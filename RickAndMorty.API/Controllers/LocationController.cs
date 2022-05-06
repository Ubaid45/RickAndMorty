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
    public async Task<IActionResult> GetAllLocations(CancellationToken ct)
    {
        _logger.LogInformation("Getting all the locations");
        var locations = await _locationService.GetAllEntities(ct);
        return Ok(locations);
    }

    [HttpGet]
    public async Task<IActionResult> GetASingleLocation(int id, CancellationToken ct)
    {
        _logger.LogInformation("Getting a single location");
        var location = await _locationService.GetASingleEntity(id, ct);
        return Ok(location);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMultipleLocations([FromQuery] int[]? ids, CancellationToken ct)
    {
        _logger.LogInformation("Getting the multiple locations");
        var locations = await _locationService.GetMultipleEntities(ids, ct);
        return Ok(locations);
    }
    
    [HttpGet]
    public async Task<IActionResult> FilterLocations(CancellationToken ct)
    {
        IQueryCollection queryParams = HttpContext.Request.Query;
        _logger.LogInformation("Filter the locations");
        var filterLocatins = await _locationService.FilterEntities(queryParams, ct);
        return Ok(filterLocatins);
    }
}