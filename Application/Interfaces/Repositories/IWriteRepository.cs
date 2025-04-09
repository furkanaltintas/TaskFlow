using Domain.Common;

namespace Application.Interfaces.Repositories;

public interface IWriteRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    Task<bool> AddAsync(TEntity entity);
    Task<bool> AddRangeAsync(List<TEntity> entities);
    bool Remove(TEntity entity);
    bool RemoveRange(List<TEntity> entities);
    Task<bool> RemoveAsync(int id);
    bool Update(TEntity entity);
}