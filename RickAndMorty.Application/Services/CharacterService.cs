using AutoMapper;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;

namespace RickAndMorty.Application.Services;

public class CharacterService : BaseService, ICharacterService
{
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper, IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _mapper = mapper;
    }


    public async Task<ServiceResponse<IEnumerable<Character>>?> GetAllEntities(CancellationToken ct)
    {
        return await ProcessRequest<ServiceResponse<IEnumerable<Character>>>("/api/character", ct);
    }

    public async Task<Character?> GetASingleEntity(int id, CancellationToken ct)
    {
        return await ProcessRequest<Character>($"/api/character{id}", ct);
    }

    public async Task<ServiceResponse<IEnumerable<Character>>?> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        return await ProcessRequest<ServiceResponse<IEnumerable<Character>>>($"/api/character/{ids}", ct);
    }

    public Task<ServiceResponse<IEnumerable<Character>>> FilterCharacters(string name, CharacterStatus? characterStatus,
        string species, string type,
        CharacterGender? gender, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}