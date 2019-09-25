using System;
using AutoMapper;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        Mapper.CreateMap<Customer, CustomerDto>();
        Mapper.CreateMap<CustomerDto, Customer>();
    }
}