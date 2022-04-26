using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Net.Api.Models.Enums;
using RickAndMorty.Net.Api.Service;
using Character = RickAndMorty.Net.Api.Models.Domain.Character;

namespace RickAndMorty.Application.Services;

public class RickAndMortyApiProxy : IRickAndMortyApi
{
    private RickAndMortyApi _rickAndMortyApi;
    

    public Task<Character> GetCharacter(int id)
    {
        if (_rickAndMortyApi == null) // Lazy initialization
        {
            _rickAndMortyApi = new RickAndMortyApi();
        }

        return _rickAndMortyApi.GetCharacter(id);
    }

    public Task<IEnumerable<Character>> GetAllCharacters()
    {
        if (_rickAndMortyApi == null) // Lazy initialization
        {
            _rickAndMortyApi = new RickAndMortyApi();
        }

        return _rickAndMortyApi.GetAllCharacters();
    }

    public Task<IEnumerable<Character>> GetMultipleCharacters(int[] ids)
    {
        if (_rickAndMortyApi == null) // Lazy initialization
        {
            _rickAndMortyApi = new RickAndMortyApi();
        }

        return _rickAndMortyApi.GetMultipleCharacters(ids);
    }

    public Task<IEnumerable<Character>> FilterCharacters(string name, CharacterStatus? characterStatus, string species, string type,
        CharacterGender? gender)
    {
        if (_rickAndMortyApi == null) // Lazy initialization
        {
            _rickAndMortyApi = new RickAndMortyApi();
        }

        return _rickAndMortyApi.FilterCharacters(name, characterStatus, species, type, gender);
    }
}