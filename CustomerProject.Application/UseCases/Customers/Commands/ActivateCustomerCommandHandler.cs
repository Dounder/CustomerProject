using AutoMapper;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class ActivateCustomerCommandHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<ActivateCustomerCommand, Unit>
{
    public async Task<Unit> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await repository.Customers.GetByIdAsync(request.Id, withDeleted: true);

        if (customer == null) throw new NotFoundException("Customer not found");

        if (customer.DeletedAt == null) throw new BadRequestException("Customer is already active");

        customer.DeletedAt = null;

        repository.Customers.Update(customer);

        await repository.CommitAsync();

        return Unit.Value;
    }
}