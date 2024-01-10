using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data;

namespace CleanArch.Infrastructure.Repositories;

public class CustomerRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<Customer>(context, mapper), ICustomerRepository
{
}