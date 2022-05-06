using System.ComponentModel;

namespace RickAndMorty.Application.Abstraction.Models.Characters;

[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public enum CharacterGender
{
    [Description("Female")]
    Female,
    [Description("Male")]
    Male,
    [Description("Genderless")]
    Genderless,
    [Description("Unknown")]
    Unknown,
}