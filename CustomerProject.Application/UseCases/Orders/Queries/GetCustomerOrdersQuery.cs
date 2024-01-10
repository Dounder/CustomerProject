using CleanArch.Application.UseCases.Orders.DTOs;
using CleanArch.Domain.Common;
using MediatR;

namespace CleanArch.Application.UseCases.Orders.Queries;

public class GetCustomerOrdersQuery(int customerId, PaginationParams paginationParams) : IRequest<IEnumerable<OrderDto>>
{
    public int CustomerId { get; set; } = customerId;

    public PaginationParams Pagination { get; set; } = paginationParams;
}