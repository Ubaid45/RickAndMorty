using AutoMapper;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Abstraction.Models;
using System.Net.Http;
using System.Text.Json;

namespace RickAndMorty.Application.Services;

public class CharacterService: ICharacterService
{
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _clientFactory;

    public CharacterService(IMapper mapper, IHttpClientFactory clientFactory)
    {
        _mapper = mapper;
        _clientFactory = clientFactory;
    }

    public async Task<ServiceResponse<Character>> GetAllCharacters(CancellationToken ct)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/character");
        
        var client = _clientFactory.CreateClient("apiClient");
        
        var response = await client.SendAsync(request, ct);
        
        if (response.IsSuccessStatusCode)
        {
            try
            {
                var responseStream = await response.Content.ReadAsStreamAsync(ct);
                return await JsonSerializer.DeserializeAsync
                    <ServiceResponse<Character>>(responseStream, cancellationToken: ct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
           
        }
        else
        {
            // Error Handling
        }

        return null;
    }
}