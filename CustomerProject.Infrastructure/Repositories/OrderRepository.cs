using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data;

namespace CleanArch.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<Order>(context, mapper), IOrderRepository
{
}