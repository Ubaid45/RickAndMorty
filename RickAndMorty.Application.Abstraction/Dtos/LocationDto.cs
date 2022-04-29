using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Dtos;

public class LocationDto
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }
}