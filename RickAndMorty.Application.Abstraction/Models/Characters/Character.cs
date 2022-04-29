using System.Text.Json.Serialization;

namespace RickAndMorty.Application.Abstraction.Models.Characters;

public class Character
{
  public Character(
              int id = 0,
              string name = "",
              CharacterStatus status = CharacterStatus.Alive,
              string species = "",
              string type = "",
              CharacterGender gender = CharacterGender.Female,
              CharacterLocation location = null,
              CharacterOrigin origin = null,
              Uri image = null,
              IEnumerable<Uri> episode = null,
              Uri url = null,
              DateTime? created = null)
            {
              Id = id;
              Name = name;
              Status = status;
              Species = species;
              Type = type;
              Gender = gender;
              Location = location;
              Origin = origin;
              Image = image;
              Episode = episode;
              Url = url;
              Created = created;
            }
            [JsonPropertyName("id")]

            public int Id { get; }
            [JsonPropertyName("name")]

            public string Name { get; }
            [JsonPropertyName("status")]

            public CharacterStatus Status { get; }
            [JsonPropertyName("species")]

            public string Species { get; }
            [JsonPropertyName("type")]

            public string Type { get; }
            [JsonPropertyName("gender")]

            public CharacterGender Gender { get; }
            [JsonPropertyName("location")]
            public CharacterLocation Location { get; }
            [JsonPropertyName("origin")]

            public CharacterOrigin Origin { get; }
            [JsonPropertyName("image")]

            public Uri Image { get; }
            [JsonPropertyName("episode")] 

            public IEnumerable<Uri> Episode { get; }
            [JsonPropertyName("url")]

            public Uri Url { get; }
            [JsonPropertyName("created")]

            public DateTime? Created { get; }
            
        
}