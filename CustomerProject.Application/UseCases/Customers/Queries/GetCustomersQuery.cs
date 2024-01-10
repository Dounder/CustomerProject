using CleanArch.Application.UseCases.Customers.DTOs;
using CleanArch.Domain.Common;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Queries;

public class GetCustomersQuery(PaginationParams pagination) : IRequest<IEnumerable<CustomerDto>>
{
    public PaginationParams Pagination { get; } = pagination;
}