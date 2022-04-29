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

   
}