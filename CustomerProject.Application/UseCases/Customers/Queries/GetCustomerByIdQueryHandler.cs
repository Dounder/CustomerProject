using AutoMapper;
using CleanArch.Application.UseCases.Customers.DTOs;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Queries;

public class GetCustomerByIdQueryHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<GetCustomerByIdQuery, CustomerWithOrdersDto>
{
    public async Task<CustomerWithOrdersDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await repository.Customers.GetByIdAsyncMap<CustomerWithOrdersDto>(request.Id);

        if (customer == null) throw new NotFoundException($"Customer not found");

        if (customer.DeletedAt != null) throw new NotFoundException($"Customer was deleted, talk to administrator");

        return customer;
    }
}