using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models.Episodes;

public class Episode
{
    public Episode(
        int id = 0,
        string name = "",
        DateTime? airDate = null,
        string episodeCode = "",
        IEnumerable<Uri> characters = null,
        Uri url = null,
        DateTime? created = null)
    {
        Id = id;
        Name = name;
        AirDate = airDate;
        EpisodeCode = episodeCode;
        Characters = characters;
        Url = url;
        Created = created;
    }
    [JsonPropertyName("id")]

    public int Id { get; }
    [JsonPropertyName("name")]

    public string Name { get; }
    [JsonPropertyName("air_date")]

    public DateTime? AirDate { get; }
    [JsonPropertyName("episode")]

    public string EpisodeCode { get; }
    [JsonPropertyName("characters")]

    public IEnumerable<Uri> Characters { get; }
    [JsonPropertyName("url")]

    public Uri Url { get; }
    [JsonPropertyName("created")]

    public DateTime? Created { get; }
}