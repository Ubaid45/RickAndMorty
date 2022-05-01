using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Episodes;
using RickAndMorty.Application.Common;

namespace RickAndMorty.Application.Services;

public class EpisodeService : BaseService, IEpisodeService
{

    public EpisodeService(IMapper mapper, IHttpClientFactory clientFactory) : base(mapper, clientFactory)
    {
        
    }

    public async Task<ServiceResponse<IEnumerable<Episode>>> GetAllEntities(CancellationToken ct)
    {
        return await ProcessRequest<ServiceResponse<IEnumerable<Episode>>>("/api/episode", ct);
    }

    public async Task<Episode> GetASingleEntity(int id, CancellationToken ct)
    {
        return await ProcessRequest<Episode>($"/api/episode/{id}", ct);
    }

    public async Task<IEnumerable<Episode>> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        return await ProcessRequest<IEnumerable<Episode>>($"/api/episode/{string.Join(",",ids)}", ct);
    }

    public async Task<ServiceResponse<IEnumerable<Episode>>> FilterEntities(IQueryCollection queryParams, CancellationToken ct)
    {
        var filteredEpisodes = await ProcessRequest<ServiceResponse<IEnumerable<Episode>>>($"/api/episode/?{StringUtils.BuildQueryString(queryParams)}", ct);
        return filteredEpisodes ??  throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }
}