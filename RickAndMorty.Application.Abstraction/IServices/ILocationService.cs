using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Locations;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface ILocationService: IEntity<Location>
{
    Task<ServiceResponse<IEnumerable<Location>>> FilterLocations(string name, string type, string dimension,
        CancellationToken ct);
}