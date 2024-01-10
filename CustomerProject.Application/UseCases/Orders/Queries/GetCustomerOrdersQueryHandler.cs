using AutoMapper;
using CleanArch.Application.UseCases.Customers.Services;
using CleanArch.Application.UseCases.Orders.DTOs;
using CleanArch.Domain.Common;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Orders.Queries;

public class GetCustomerOrdersQueryHandler(IUnitOfWork repository, IMapper mapper, CustomerService service)
    : IRequestHandler<GetCustomerOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
    {
        await service.GetCustomerAsync(request.CustomerId);

        var filter = new FilterParams<Order>
        {
            Pagination = request.Pagination,
            Where = x => x.CustomerId == request.CustomerId,
        };

        var orders = await repository.Orders.GetAllAsyncMap<OrderDto>(filter);

        return orders;
    }
}