using AutoMapper;
using Bank.Data.Entities;
using Bank.Models.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountBaseModel>().ReverseMap();
            CreateMap<AccountCreateModel, Account>()
                .ForMember(opt => opt.Id, opt => opt.Ignore());
            CreateMap<AccountUpdateModel, Account>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.AccountTypeId, opt => opt.MapFrom(src => src.AccountTypeId));
        }
    }
}
