using AutoMapper;
using Bank.Data.Entities;
using Bank.Models.Models.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientBaseModel>().ReverseMap();
            CreateMap<ClientCreateModel, Client>()
                .ForMember(opt => opt.Id, opt => opt.Ignore());
            CreateMap<ClientUpdateModel, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.ClientTypeId, opt => opt.MapFrom(src => src.ClientTypeId));
        }
    }
}
