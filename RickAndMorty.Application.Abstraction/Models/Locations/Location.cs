using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models.Locations;

public class Location
{
    public Location(
        int id = 0,
        string name = "",
        string type = "",
        string dimension = "",
        IEnumerable<string> residents = null,
        string url = null,
        DateTime? created = null)
    {
        Id = id;
        Name = name;
        Type = type;
        Dimension = dimension;
        Residents = residents;
        Url = url;
        Created = created;
    }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]

    public string Name { get; set; }
    [JsonPropertyName("type")]

    public string Type { get; set; }
    [JsonPropertyName("dimension")]

    public string Dimension { get; set; }
    [JsonPropertyName("residents")]

    public IEnumerable<string> Residents { get; set; }
    [JsonPropertyName("url")]

    public string Url { get; set; }
    [JsonPropertyName("created")]

    public DateTime? Created { get; set; }
}