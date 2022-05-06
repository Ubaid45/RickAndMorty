using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models.Characters;

public class CharacterDto
{
    [JsonPropertyName("id")] public int Id { get; }
    [JsonPropertyName("name")] public string Name { get; }
    [JsonPropertyName("status")] public CharacterStatus Status { get; }
    [JsonPropertyName("statusDescription")] public string StatusDescription { get; }
    [JsonPropertyName("species")] public string Species { get; }
    [JsonPropertyName("type")] public string Type { get; }
    [JsonPropertyName("gender")] public CharacterGender Gender { get; }
    [JsonPropertyName("genderDescription")] public string GenderDescription { get; }
    [JsonPropertyName("location")] public CharacterLocation Location { get; }
    [JsonPropertyName("origin")] public CharacterOrigin Origin { get; }
    [JsonPropertyName("image")] public Uri Image { get; }
    [JsonPropertyName("episode")] public IEnumerable<Uri> Episode { get; }
    [JsonPropertyName("url")] public Uri Url { get; }
    [JsonPropertyName("created")] public DateTime? Created { get; }

}