using AutoMapper;
using CleanArch.Application.UseCases.Customers.Services;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class UpdateCustomerCommandHandler(IUnitOfWork repository, IMapper mapper, CustomerService service)
    : IRequestHandler<UpdateCustomerCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await service.GetCustomerAsync(request.Id);

        customer = mapper.Map(request, customer);

        repository.Customers.Update(customer);

        await repository.CommitAsync();

        return Unit.Value;
    }
}