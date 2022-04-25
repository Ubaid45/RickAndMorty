using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models;

public class Episode
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("air_date")]
    public DateTime AirDate { get; set; }
    [JsonPropertyName("episode")]
    public string EpisodeNumber { get; set; }
    [JsonPropertyName("characters")]
    public List<string> Characters { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }
}