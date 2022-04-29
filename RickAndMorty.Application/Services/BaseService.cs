using System.Text;
using System.Text.Json;
using RickAndMorty.Application.Abstraction.Models;

namespace RickAndMorty.Application.Services;

public abstract class BaseService
{
    protected readonly IHttpClientFactory ClientFactory;

    protected BaseService(IHttpClientFactory clientFactory)
    {
        ClientFactory = clientFactory;
    }

    protected async Task<ServiceResponse<T>?> ProcessRequest<T>(string uri, CancellationToken ct)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, uri);

                var client = ClientFactory.CreateClient("apiClient");

                var response = await client.SendAsync(request, ct);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync(ct);
                    
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        String responseString = reader.ReadToEnd();
                    
                    return await JsonSerializer.DeserializeAsync
                        <ServiceResponse<T>>(responseStream, cancellationToken: ct);
                }
                else
                {
                    // Error Handling
                }

                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
}
