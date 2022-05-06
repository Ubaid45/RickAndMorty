using System.Text;
using Newtonsoft.Json;
using RickAndMorty.Data.Abstraction;

namespace RickAndMorty.Data;

public class HttpRequestHandler: IHttpRequestHandler
{
    private readonly IHttpClientFactory _clientFactory;
    
    public HttpRequestHandler(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<T?> ProcessRequest<T>( string uri, CancellationToken ct) where T : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);

        var client = _clientFactory.CreateClient("apiClient");

        var response = await client.SendAsync(request, ct);

        if (!response.IsSuccessStatusCode) return null;

        var responseStream = await response.Content.ReadAsStreamAsync(ct);
        var reader = new StreamReader(responseStream, Encoding.UTF8);
        var responseString = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject<T>(responseString);
    }

}