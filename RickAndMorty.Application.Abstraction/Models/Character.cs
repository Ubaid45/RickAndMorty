using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using RickAndMorty.Application.Abstraction.Dtos;

namespace RickAndMorty.Application.Abstraction.Models;

public class Character
{
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("species")]
        public string Species { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CharacterGender gender { get; set; }
        [JsonPropertyName("origin")]
        public Origin Origin { get; set; }
        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("episode")] 
        public List<string> Episodes { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        
}