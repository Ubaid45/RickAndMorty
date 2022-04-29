using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models.Characters;

public class CharacterLocation
{

    public CharacterLocation(string name = "", Uri url = null)
    {
        Name = name;
        Url = url;
    }

    [JsonPropertyName("name")]

    public string Name { get; set; }
    [JsonPropertyName("url")]

    public Uri Url { get; set; }
}