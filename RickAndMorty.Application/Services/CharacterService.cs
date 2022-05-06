using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RickAndMorty.Application.Abstraction.Exceptions;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Common;
using RickAndMorty.Data.Abstraction;

namespace RickAndMorty.Application.Services;

public class CharacterService : ICharacterService
{
    private readonly IHttpRequestHandler _httpRequestHandler;
    private readonly IMapper _mapper;
    public CharacterService(IHttpRequestHandler httpRequestHandler, IMapper mapper)
    {
        _httpRequestHandler = httpRequestHandler;
        _mapper = mapper;
    }


    public async Task<ServiceResponse<List<Character?>>> GetAllEntities(CancellationToken ct)
    {
        var allCharacters = await _httpRequestHandler.ProcessRequest<ServiceResponse<List<Character?>>>("/api/character", ct);
        return allCharacters ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<Character?> GetASingleEntity(int id, CancellationToken ct)
    {
        var character =  await _httpRequestHandler.ProcessRequest<Character>($"/api/character/{id}", ct);
        return character ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<List<Character?>> GetMultipleEntities(int[]? ids, CancellationToken ct)
    {
        var url = string.Empty;
        if (ids != null) url = $"/api/character/{string.Join(",", ids)}";
        
        var multipleCharacters = await _httpRequestHandler.ProcessRequest<List<Character?>>(url, ct);
        return multipleCharacters ??  throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));
    }

    public async Task<ServiceResponse<List<Character?>>> FilterEntities(IQueryCollection? queryParams,
        CancellationToken ct)
    {
        var url = string.Empty;
        if (queryParams != null) url = $"/api/character/?{StringUtils.BuildQueryString(queryParams)}";
        
        var filteredCharacters = await _httpRequestHandler.ProcessRequest<ServiceResponse<List<Character?>>>(
                url , ct);
        return filteredCharacters ?? throw new HttpStatusException(HttpStatusCode.BadRequest, nameof(ErrorCodes.BadRequestParameters));

    }
}