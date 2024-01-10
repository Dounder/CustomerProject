using AutoMapper;
using CleanArch.Application.UseCases.Customers.Commands;
using CleanArch.Application.UseCases.Customers.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, CustomerWithOrdersDto>()
            .ForMember(x => x.Orders, opt => opt.MapFrom(src => src.Orders));

        CreateMap<CreateCustomerCommand, Customer>();

        CreateMap<UpdateCustomerCommand, Customer>()
            .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
    }
}