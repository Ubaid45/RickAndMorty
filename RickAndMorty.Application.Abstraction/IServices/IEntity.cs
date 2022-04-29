using RickAndMorty.Application.Abstraction.Models;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface IEntity<T>
{
    Task<ServiceResponse<IEnumerable<T>>> GetAllEntities(CancellationToken ct);

    Task<ServiceResponse<T>> GetASingleEntity(int id, CancellationToken ct);

    Task<ServiceResponse<IEnumerable<T>>> GetMultipleEntities(int[] ids, CancellationToken ct);

}