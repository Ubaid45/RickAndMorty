using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Models;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface IEntity<T>
{
    Task<ServiceResponse<IEnumerable<T>>> GetAllEntities(CancellationToken ct);

    Task<T> GetASingleEntity(int id, CancellationToken ct);

    Task<IEnumerable<T>> GetMultipleEntities(int[] ids, CancellationToken ct);

    Task<ServiceResponse<IEnumerable<T>>> FilterEntities(IQueryCollection queryParams, CancellationToken ct);
}