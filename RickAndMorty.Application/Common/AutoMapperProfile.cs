using AutoMapper;
using RickAndMorty.Application.Abstraction.Dtos;
using RickAndMorty.Application.Abstraction.Models;
using RickAndMorty.Application.Abstraction.Models.Locations;

namespace RickAndMorty.Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Location, LocationDto>();
        //CreateMap<Character, CharacterDto>();
    }
}