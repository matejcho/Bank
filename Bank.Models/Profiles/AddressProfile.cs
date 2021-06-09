using AutoMapper;
using Bank.Data.Entities;
using Bank.Models.Models.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressBaseModel>().ReverseMap();
            CreateMap<AddressCreateModel, Address>()
                .ForMember(opt => opt.Id, opt => opt.Ignore());
            CreateMap<AddressUpdateModel, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street));

        }
    }
}
