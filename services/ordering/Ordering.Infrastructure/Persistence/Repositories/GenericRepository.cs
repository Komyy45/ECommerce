using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Persistence.Data;

namespace Ordering.Infrastructure.Persistence.Repositories;

public abstract class GenericRepository<TEntity, TKey>(OrderingContext context) : IGenericRepository<TEntity, TKey>
where TEntity : BaseEntity<TKey>
where TKey : IComparable<TKey>
{
    public async Task<IEnumerable<TEntity>> GetAll(bool withChangeTracking = true)
    {
        if (withChangeTracking) return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(TKey id)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id!.Equals(id));
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }
}