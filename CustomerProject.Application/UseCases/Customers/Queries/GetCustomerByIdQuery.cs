using CleanArch.Application.UseCases.Customers.DTOs;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Queries;

public class GetCustomerByIdQuery(int id) : IRequest<CustomerWithOrdersDto>
{
    public int Id { get; set; } = id;
}