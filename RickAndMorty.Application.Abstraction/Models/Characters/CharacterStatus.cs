using System.ComponentModel;

namespace RickAndMorty.Application.Abstraction.Models.Characters;

[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public enum CharacterStatus
{
    [Description("Alive")]
    Alive,
    [Description("Dead")]
    Dead,
    [Description("Unknown")]
    Unknown
}