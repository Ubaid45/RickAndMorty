using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Episodes;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface IEpisodeService : IEntity<Episode>
{
    Task<ServiceResponse<IEnumerable<Episode>>> FilterEpisodes(string name, string episode, CancellationToken ct);
}