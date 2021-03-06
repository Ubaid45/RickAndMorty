using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models;

public class Info
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("pages")] public int Pages { get; set; }
    [JsonPropertyName("next")] public string Next { get; set; }
    [JsonPropertyName("prev")] public string Previous { get; set; }
}