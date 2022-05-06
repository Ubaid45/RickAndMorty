using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Abstraction.Models.Episodes;
using RickAndMorty.Application.Common;
using RickAndMorty.Data.Abstraction;

namespace RickAndMorty.Application.Services;

public class EpisodeService : IEpisodeService
{
    private readonly IHttpRequestHandler _httpRequestHandler;
    private readonly IMapper mapper;
    public EpisodeService(IHttpRequestHandler httpRequestHandler, IMapper mapper)
    {
        _httpRequestHandler = httpRequestHandler;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<Episode?>>> GetAllEntities(CancellationToken ct)
    {
        var allEpisodes = await _httpRequestHandler.ProcessRequest<ServiceResponse<List<Episode?>>>("/api/episode", ct);
         return allEpisodes ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<Episode?> GetASingleEntity(int id, CancellationToken ct)
    {
        var episode = await _httpRequestHandler.ProcessRequest<Episode>($"/api/episode/{id}", ct);
        return episode ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<List<Episode?>> GetMultipleEntities(int[]? ids, CancellationToken ct)
    {
        
        var url = string.Empty;
        if (ids != null) url = $"/api/episode/{string.Join(",", ids)}";
        
        var multipleEpisodes = await _httpRequestHandler.ProcessRequest<List<Episode?>>(url, ct);
        return multipleEpisodes ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<ServiceResponse<List<Episode?>>> FilterEntities(IQueryCollection? queryParams, CancellationToken ct)
    {
        var url = string.Empty;
        if (queryParams != null) url = $"/api/character/?{StringUtils.BuildQueryString(queryParams)}";
        
        var filteredEpisodes = await _httpRequestHandler.ProcessRequest<ServiceResponse<List<Episode?>>>(url, ct);
        return filteredEpisodes ??  throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }
}