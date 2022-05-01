using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Common;

namespace RickAndMorty.Application.Services;

public class CharacterService : BaseService, ICharacterService
{

    public CharacterService(IMapper mapper, IHttpClientFactory clientFactory) : base(mapper, clientFactory)
    {
    }


    public async Task<ServiceResponse<IEnumerable<Character>>?> GetAllEntities(CancellationToken ct)
    {
        return await ProcessRequest<ServiceResponse<IEnumerable<Character>>>("/api/character", ct);
    }

    public async Task<Character?> GetASingleEntity(int id, CancellationToken ct)
    {
        return await ProcessRequest<Character>($"/api/character/{id}", ct);
    }

    public async Task<IEnumerable<Character>?> GetMultipleEntities(int[] ids, CancellationToken ct)
    {
        return await ProcessRequest<IEnumerable<Character>>($"/api/character/{string.Join(",",ids)}", ct);
    }

    public async Task<ServiceResponse<IEnumerable<Character>>> FilterEntities(IQueryCollection queryParams, CancellationToken ct)
    {
        var filteredCharacters = await ProcessRequest<ServiceResponse<IEnumerable<Character>>>($"/api/character/?{StringUtils.BuildQueryString(queryParams)}", ct);
        return filteredCharacters ??  throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }
}