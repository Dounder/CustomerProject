using AutoMapper;
using CleanArch.Application.UseCases.Customers.Services;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class DeleteCustomerCommandHandler(IUnitOfWork repository, CustomerService service)
    : IRequestHandler<DeleteCustomerCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await service.GetCustomerAsync(request.Id);

        if (customer.Orders.Count > 0) throw new BadRequestException($"Customer has orders.");

        customer.DeletedAt = DateTime.Now;

        repository.Customers.Update(customer);

        await repository.CommitAsync();

        return Unit.Value;
    }
}