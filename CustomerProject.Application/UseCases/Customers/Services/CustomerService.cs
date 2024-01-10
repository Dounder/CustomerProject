using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.UseCases.Customers.Services;

public class CustomerService(IUnitOfWork repository, IMapper mapper)
{
    public async Task<Customer> GetCustomerAsync(int id)
    {
        var customer = await repository.Customers.GetByIdAsync(id);

        if (customer == null) throw new NotFoundException("Customer not found");
        if (customer.DeletedAt != null) throw new NotFoundException("Customer was deleted, talk to administrator");

        return customer;
    }
}