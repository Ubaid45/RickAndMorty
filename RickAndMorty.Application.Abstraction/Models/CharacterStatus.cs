using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RickAndMorty.Application.Abstraction.Models;

[JsonConverter(typeof(StringEnumConverter))]  
public enum CharacterStatus
{
    Alive,
    Dead,
    unknown
}