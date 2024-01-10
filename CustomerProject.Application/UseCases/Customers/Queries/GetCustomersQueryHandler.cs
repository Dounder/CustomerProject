using AutoMapper;
using CleanArch.Application.UseCases.Customers.DTOs;
using CleanArch.Domain.Common;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Queries;

public class GetCustomersQueryHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
{
    public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var filters = new FilterParams<Customer> { Pagination = request.Pagination };
        var customers = await repository.Customers.GetAllAsync(filters);
        return mapper.Map<IEnumerable<CustomerDto>>(customers);
    }
}