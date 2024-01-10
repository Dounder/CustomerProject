using AutoMapper;
using CleanArch.Application.UseCases.Customers.DTOs;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class CreateCustomerCommandHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(request);
        await repository.Customers.Add(customer);
        await repository.CommitAsync();
        return mapper.Map<CustomerDto>(customer);
    }
}