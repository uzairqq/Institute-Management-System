using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sms.Domain.Dto;
using Sms.Domain.Entities;

namespace Sms.Domain.Mappings
{
   public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            //CreateMap<CustomerRates, CustomerRatesResponseDto>().ReverseMap();
            //CreateMap<CustomerRates, CustomerRatesRequestDto>().ReverseMap();
            //CreateMap<Customer, CustomerResponseDto>()
            //    .ForMember(x => x.Type, opt => { opt.MapFrom(o => o.CustomerType.Type); }).ReverseMap();
        }
    }
}
