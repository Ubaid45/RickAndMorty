using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Net.Api.Factory;
using RickAndMorty.Net.Api.Models.Enums;
using RickAndMorty.Net.Api.Service;

namespace RickAndMorty.Application.Services;

public class RickAndMortyApi 
{
    private readonly IRickAndMortyService _rickAndMortyService;

    public RickAndMortyApi()
    {
        _rickAndMortyService = RickAndMortyApiFactory.Create();
    }

    public Task<Net.Api.Models.Domain.Character> GetCharacter(int id)
    {
        return _rickAndMortyService.GetCharacter(id);
    }

    public Task<IEnumerable<Net.Api.Models.Domain.Character>> GetAllCharacters()
    {
        return _rickAndMortyService.GetAllCharacters();
    }

    public Task<IEnumerable<Net.Api.Models.Domain.Character>> GetMultipleCharacters(int[] ids)
    {
        return _rickAndMortyService.GetMultipleCharacters(ids);
    }

    public  Task<IEnumerable<Net.Api.Models.Domain.Character>> FilterCharacters(string name,
        CharacterStatus? characterStatus, string species, string type,
        CharacterGender? gender)
    {
        return _rickAndMortyService.FilterCharacters(name, characterStatus, species, type, gender);
    }
    

}