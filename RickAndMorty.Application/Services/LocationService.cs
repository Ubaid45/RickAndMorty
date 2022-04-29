using AutoMapper;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Locations;

namespace RickAndMorty.Application.Services;

public class LocationService : BaseService, ILocationService
{
    private readonly IMapper _mapper;

    public LocationService(IMapper mapper, IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _mapper = mapper;
    }

    public async Task<ServiceResponse<IEnumerable<Location>>?> GetAllEntities(CancellationToken ct)
    {
        return await ProcessRequest<ServiceResponse<IEnumerable<Location>>>("/api/location", ct);
    }

    public async Task<Location> GetASingleEntity(int id, CancellationToken ct)
    {
        return await ProcessRequest<Location?>($"/api/location/{id}", ct);
        
    }

    public Task<ServiceResponse<IEnumerable<Location>>> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Location>>> FilterLocations(string name, string type, string dimension,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}