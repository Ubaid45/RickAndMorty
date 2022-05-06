namespace RickAndMorty.Data.Abstraction;

public interface IHttpRequestHandler
{
    Task<T?> ProcessRequest<T>(string uri, CancellationToken ct) where T : class;
}