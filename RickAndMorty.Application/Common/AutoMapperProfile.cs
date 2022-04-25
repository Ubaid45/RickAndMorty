using AutoMapper;
using RickAndMorty.Application.Abstraction.Dtos;
using RickAndMorty.Application.Abstraction.Models;

namespace RickAndMorty.Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<LocationDto, Location>();
    }
}