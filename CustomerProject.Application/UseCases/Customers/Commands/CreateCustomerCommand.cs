using CleanArch.Application.UseCases.Customers.DTOs;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public string Name { get; set; }
}