using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class DeleteCustomerCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}