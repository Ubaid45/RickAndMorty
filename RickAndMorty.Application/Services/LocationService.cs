using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Abstraction.Models.Locations;
using RickAndMorty.Application.Common;
using RickAndMorty.Data.Abstraction;

namespace RickAndMorty.Application.Services;

public class LocationService : ILocationService
{
    private readonly IHttpRequestHandler _httpRequestHandler;
    private readonly IMapper mapper;

    public LocationService(IHttpRequestHandler httpRequestHandler, IMapper mapper)
    {
        _httpRequestHandler = httpRequestHandler;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<Location?>>> GetAllEntities(CancellationToken ct)
    {
        var allLocations = await _httpRequestHandler.ProcessRequest<ServiceResponse<List<Location?>>>("/api/location", ct);
        return allLocations ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<Location?> GetASingleEntity(int id, CancellationToken ct)
    {
        var location = await _httpRequestHandler.ProcessRequest<Location>($"/api/location/{id}", ct);
        return location?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<List<Location?>> GetMultipleEntities(int[]? ids, CancellationToken ct)
    {
        
        var url = string.Empty;
        if (ids != null) url = $"/api/location/{string.Join(",", ids)}";
        
        var multipleLocations = await _httpRequestHandler.ProcessRequest<List<Location?>>(url, ct);
        return multipleLocations?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<ServiceResponse<List<Location?>>> FilterEntities(IQueryCollection? queryParams,
        CancellationToken ct)
    {
        var url = string.Empty;
        if (queryParams != null) url = $"/api/character/?{StringUtils.BuildQueryString(queryParams)}";
        
        var filteredLocations = await _httpRequestHandler.ProcessRequest<ServiceResponse<List<Location?>>>(url, ct);
        return filteredLocations ??  throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }
}