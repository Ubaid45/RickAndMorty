using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models;

public class ServiceResponse<T>
{
    [JsonPropertyName("info")] public Info Info { get; set; }
    [JsonPropertyName("results")] public T Results { get; set; }
}