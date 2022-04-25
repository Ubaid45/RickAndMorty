using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RickAndMorty.Application.Abstraction.Models;
[JsonConverter(typeof(StringEnumConverter))]
public enum CharacterGender
{
    Female,
    Male,
    Genderless,
    unknown
}