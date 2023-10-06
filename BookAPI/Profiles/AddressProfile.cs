using AutoMapper;
using BookAPI.Data.Dtos;
using BookAPI.Models;

namespace BookAPI.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile ()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, UpdateAddressDto>();
    }
}
