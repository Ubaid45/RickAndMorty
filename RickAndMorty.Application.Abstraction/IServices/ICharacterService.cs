using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Abstraction.Models.Episodes;
using RickAndMorty.Application.Abstraction.Models.Locations;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface ICharacterService: IEntity<Character>
{
    Task<ServiceResponse<IEnumerable<Character>>> FilterCharacters(string name, CharacterStatus? characterStatus,
        string species, string type,
        CharacterGender? gender, CancellationToken ct);
}