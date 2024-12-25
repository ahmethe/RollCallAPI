using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForAuthenticationDto, User>();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerDtoForUpdate, Customer>();
            CreateMap<PaymentDto, Payment>().ReverseMap();
            CreateMap<PaymentDtoForManipulation, Payment>();
            CreateMap<PaymentDtoForManipulation, PaymentDto>();
        }
    }
}
