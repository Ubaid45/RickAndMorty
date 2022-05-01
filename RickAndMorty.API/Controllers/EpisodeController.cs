using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.IServices;

namespace RickAndMorty.API.Controllers;

[Route("api/[action]")]
[ApiController]
public class EpisodeController : Controller
{
    private readonly IEpisodeService _episodeService;
    private readonly ILogger<EpisodeController> _logger;

    public EpisodeController(IEpisodeService episodeService, ILogger<EpisodeController> logger)
    {
        _episodeService = episodeService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEpisodes(CancellationToken ct)
    {
        _logger.LogInformation("Getting all the episodes");
        var episodes = await _episodeService.GetAllEntities(ct);
        return Ok(episodes);
    }

    [HttpGet]
    public async Task<IActionResult> GetASingleEpisode(int id, CancellationToken ct)
    {
        _logger.LogInformation("Getting a single episode");
        var episode = await _episodeService.GetASingleEntity(id, ct);
        return Ok(episode);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMultipleEpisodes([FromQuery] int[] ids, CancellationToken ct)
    {
        _logger.LogInformation("Getting the multiple episodes");
        var multipleEpisodes = await _episodeService.GetMultipleEntities(ids, ct);
        return Ok(multipleEpisodes);
    }
    
    [HttpGet]
    public async Task<IActionResult> FilterEpisodes(CancellationToken ct)
    {
        IQueryCollection queryParams = HttpContext.Request.Query;
        _logger.LogInformation("Filter the episodes");
        var filterEpisodes = await _episodeService.FilterEntities(queryParams, ct);
        return Ok(filterEpisodes);
    }

    
}