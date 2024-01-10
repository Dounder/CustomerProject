using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    ICustomerRepository Customers { get; }
    IOrderRepository Orders { get; }
}