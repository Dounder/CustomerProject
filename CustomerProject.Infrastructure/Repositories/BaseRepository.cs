using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Domain.Common;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories;

public class BaseRepository<T>(ApplicationDbContext context, IMapper mapper) : IBaseRepository<T>
    where T : class, IBaseEntity
{
    private readonly DbSet<T> dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(int id, bool withDeleted = false)
    {
        var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null) return null;

        if (withDeleted) return entity;

        return entity.DeletedAt != null ? null : entity;
    }

    public async Task<TM?> GetByIdAsyncMap<TM>(int id)
    {
        return await dbSet.Where(x => x.Id == id).ProjectTo<TM>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(FilterParams<T> filterParams)
    {
        var (pagination, trackChanges, where, orderBy, orderByDescending) = filterParams;
        var (limit, offset) = pagination;

        IQueryable<T> query = dbSet;

        query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        query = query.Where(where);

        if (!trackChanges) query = query.AsNoTracking();

        return await query.Skip(offset).Take(limit).ToListAsync();
    }

    public async Task<IEnumerable<TM>> GetAllAsyncMap<TM>(FilterParams<T> filterParams)
    {
        var (pagination, trackChanges, where, orderBy, orderByDescending) = filterParams;
        var (limit, offset) = pagination;

        IQueryable<T> query = dbSet;

        query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        query = query.Where(where);

        if (!trackChanges) query = query.AsNoTracking();

        return await query.Skip(offset).Take(limit).ProjectTo<TM>(mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task Add(T entity) => await dbSet.AddAsync(entity);

    public async Task AddRange(IEnumerable<T> entities) => await dbSet.AddRangeAsync(entities);

    public void Update(T entity) => dbSet.Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => dbSet.UpdateRange(entities);

    public void Remove(T entity) => dbSet.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) => dbSet.RemoveRange(entities);
}