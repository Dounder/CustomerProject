using AutoMapper;
using CleanArch.Application.UseCases.Orders.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();

        CreateMap<CreateOrderDto, Order>();
    }
}