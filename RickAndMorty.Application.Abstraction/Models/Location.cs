using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models;

public class Location
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("dimension")]
    public string Dimension { get; set; }
    [JsonPropertyName("residents")]
    public List<string> Residents { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }
}