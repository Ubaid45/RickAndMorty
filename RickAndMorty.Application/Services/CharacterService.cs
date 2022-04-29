using AutoMapper;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;

namespace RickAndMorty.Application.Services;

public class CharacterService: BaseService, ICharacterService
{
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper, IHttpClientFactory clientFactory): base(clientFactory)
    {
        _mapper = mapper;
    }


    public Task<ServiceResponse<IEnumerable<Character>>> GetAllEntities(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<Character>> GetASingleEntity(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Character>>> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<IEnumerable<Character>>> FilterCharacters(string name, CharacterStatus? characterStatus, string species, string type,
        CharacterGender? gender, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}