using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class ActivateCustomerCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}