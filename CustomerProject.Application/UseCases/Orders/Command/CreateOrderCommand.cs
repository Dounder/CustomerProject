using CleanArch.Application.UseCases.Customers.DTOs;
using CleanArch.Application.UseCases.Orders.DTOs;
using MediatR;

namespace CleanArch.Application.UseCases.Orders.Command;

public class CreateOrderCommand : IRequest<List<OrderDto>>
{
    public int CustomerId { get; set; }
    public List<CreateOrderDto> Orders { get; set; }
}