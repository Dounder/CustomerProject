using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class UpdateCustomerCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
    public string? Name { get; set; } = null;
}