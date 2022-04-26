using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Net.Api.Models.Enums;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface IRickAndMortyApi
{
    Task<Net.Api.Models.Domain.Character> GetCharacter(int id);
    Task<IEnumerable<Net.Api.Models.Domain.Character>> GetAllCharacters();
    Task<IEnumerable<Net.Api.Models.Domain.Character>> GetMultipleCharacters(int[] ids);

    Task<IEnumerable<Net.Api.Models.Domain.Character>> FilterCharacters(string name,
        CharacterStatus? characterStatus, string species, string type,
        CharacterGender? gender);
}