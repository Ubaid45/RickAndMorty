using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Locations;
using RickAndMorty.Application.Common;

namespace RickAndMorty.Application.Services;

public class LocationService : BaseService, ILocationService
{

    public LocationService(IMapper mapper, IHttpClientFactory clientFactory) : base(mapper, clientFactory)
    {
    }

    public async Task<ServiceResponse<IEnumerable<Location>>?> GetAllEntities(CancellationToken ct)
    {
        return await ProcessRequest<ServiceResponse<IEnumerable<Location>>>("/api/location", ct);
    }

    public async Task<Location> GetASingleEntity(int id, CancellationToken ct)
    {
        return await ProcessRequest<Location?>($"/api/location/{id}", ct);
    }

    public async Task<IEnumerable<Location>> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        return await ProcessRequest<IEnumerable<Location>>($"/api/location/{string.Join(",",ids)}", ct);
    }

    public async Task<ServiceResponse<IEnumerable<Location>>> FilterEntities(IQueryCollection queryParams, CancellationToken ct)
    {
        var filteredLocations = await ProcessRequest<ServiceResponse<IEnumerable<Location>>>($"/api/location/?{StringUtils.BuildQueryString(queryParams)}", ct);
        return filteredLocations ??  throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }
}