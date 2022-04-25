using RickAndMorty.Application.Abstraction.Models;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface ICharacterService
{
    Task<ServiceResponse<Character>> GetAllCharacters(CancellationToken ct);
}