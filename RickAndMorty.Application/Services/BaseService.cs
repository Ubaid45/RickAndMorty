using System.Text;
using Newtonsoft.Json;

namespace RickAndMorty.Application.Services;

public abstract class BaseService
{
    protected readonly IHttpClientFactory ClientFactory;

    protected BaseService(IHttpClientFactory clientFactory)
    {
        ClientFactory = clientFactory;
    }

    protected async Task<T?> ProcessRequest<T>(string uri, CancellationToken ct) where T : class
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