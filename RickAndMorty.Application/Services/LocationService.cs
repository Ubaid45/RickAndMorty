using AutoMapper;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Locations;

namespace RickAndMorty.Application.Services;

public class LocationService: BaseService, ILocationService
{
    private readonly IMapper _mapper;

    public LocationService(IMapper mapper, IHttpClientFactory clientFactory): base(clientFactory)
    {
        _mapper = mapper;
    }
    public async Task<ServiceResponse<IEnumerable<Location>>> GetAllEntities(CancellationToken ct)
    {
        var locationList = await ProcessRequest<IEnumerable<Location>>("/api/location", ct);
        return null;

    }

    public Task<ServiceResponse<Location>> GetASingleEntity(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Location>>> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Location>>> FilterLocations(string name, string type, string dimension, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}