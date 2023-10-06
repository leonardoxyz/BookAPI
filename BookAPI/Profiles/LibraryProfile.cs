using AutoMapper;
using BookAPI.Data.Dtos;
using BookAPI.Models;

namespace BookAPI.Profiles;

public class LibraryProfile : Profile
{
    public LibraryProfile()
    {
        CreateMap<CreateLibraryDto, Library>();
        CreateMap<Library, ReadLibraryDto>()
            .ForMember(addressDto => addressDto.ReadAddressDto, opt => opt.MapFrom(library => library.Address));
        CreateMap<UpdateLibraryDto, Library>();
        CreateMap<Library, UpdateLibraryDto>();

    }
}
