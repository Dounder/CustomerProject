using AutoMapper;
using CleanArch.Application.UseCases.Customers.Services;
using CleanArch.Application.UseCases.Orders.DTOs;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Orders.Command;

public class CreateOrderCommandHandler(IUnitOfWork repository, IMapper mapper, CustomerService customerService)
    : IRequestHandler<CreateOrderCommand, List<OrderDto>>
{
    public async Task<List<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerService.GetCustomerAsync(request.CustomerId);

        var orders = mapper.Map<List<Order>>(request.Orders);

        orders = orders.Select(o =>
        {
            o.Customer = customer;
            return o;
        }).ToList();

        await repository.Orders.AddRange(orders);

        await repository.CommitAsync();

        return mapper.Map<List<OrderDto>>(orders);
    }
}