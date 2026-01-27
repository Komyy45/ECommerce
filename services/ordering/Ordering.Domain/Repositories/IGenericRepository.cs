using Ordering.Domain.Entities;

namespace Ordering.Domain.Repositories;

public interface IGenericRepository<TEntity, TKey> 
where TEntity : BaseEntity<TKey>
where TKey : IComparable<TKey>
{
    public Task<IEnumerable<TEntity>> GetAll(bool withChangeTracking = true);
    public Task<TEntity?> GetById(TKey id);
    public Task<TEntity> Add(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
}