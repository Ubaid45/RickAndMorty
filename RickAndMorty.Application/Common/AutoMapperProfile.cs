using AutoMapper;
using EnumsNET;
using RickAndMorty.Application.Abstraction.Models.Characters;
using RickAndMorty.Application.Extensions;

namespace RickAndMorty.Application.Common
{
    // TODO
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(i => i.GenderDescription,
                    o => o.MapFrom(s => ((CharacterGender) s.Gender).AsString(EnumFormat.Description)))
                .ForMember(i => i.StatusDescription,
                    o => o.MapFrom(s => ((CharacterStatus) s.Status).AsString(EnumFormat.Description)));
        }
    }
}