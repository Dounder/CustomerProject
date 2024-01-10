using AutoMapper;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data;

namespace CleanArch.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext context, IMapper mapper) : IUnitOfWork
{
    public ICustomerRepository Customers { get; } = new CustomerRepository(context, mapper);
    public IOrderRepository Orders { get; } = new OrderRepository(context, mapper);

    public async Task CommitAsync() => await context.SaveChangesAsync();

    public void Dispose() => context.Dispose();
}