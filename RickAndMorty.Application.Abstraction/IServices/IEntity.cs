using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;

namespace RickAndMorty.Application.Abstraction.IServices;

public interface IEntity<T>
{
    Task<ServiceResponse<List<T>>> GetAllEntities(CancellationToken ct);

    Task<T> GetASingleEntity(int id, CancellationToken ct);

    Task<List<T>> GetMultipleEntities(int[]? ids, CancellationToken ct);

    Task<ServiceResponse<List<T>>> FilterEntities(IQueryCollection? queryParams, CancellationToken ct);
}