using AutoMapper;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Episodes;

namespace RickAndMorty.Application.Services;

public class EpisodeService: BaseService, IEpisodeService
{
    private readonly IMapper _mapper;

    public EpisodeService(IMapper mapper, IHttpClientFactory clientFactory): base(clientFactory)
    {
        _mapper = mapper;
    }
    
    public Task<ServiceResponse<IEnumerable<Episode>>> GetAllEntities(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<Episode>> GetASingleEntity(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Episode>>> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Episode>>> FilterEpisodes(string name, string episode, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}