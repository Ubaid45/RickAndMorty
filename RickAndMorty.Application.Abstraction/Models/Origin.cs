using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models;

public class Origin
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}