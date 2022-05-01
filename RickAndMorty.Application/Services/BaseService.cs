using System.Text;
using AutoMapper;
using Newtonsoft.Json;

namespace RickAndMorty.Application.Services;

public class BaseService
{
    protected readonly IMapper Mapper;
    protected readonly IHttpClientFactory ClientFactory;
    protected BaseService(IMapper mapper, IHttpClientFactory clientFactory)
    {
        Mapper = mapper;
        ClientFactory = clientFactory;
    }
    
    protected  async Task<T?> ProcessRequest<T>( string uri, CancellationToken ct) where T : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);

        var client = ClientFactory.CreateClient("apiClient");

        var response = await client.SendAsync(request, ct);

        if (!response.IsSuccessStatusCode) return null;

        var responseStream = await response.Content.ReadAsStreamAsync(ct);
        var reader = new StreamReader(responseStream, Encoding.UTF8);
        var responseString = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject<T>(responseString);
    }
}