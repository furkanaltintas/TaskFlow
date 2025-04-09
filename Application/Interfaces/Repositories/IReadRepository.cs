using Domain.Common;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    IQueryable<TEntity> GetAll(bool tracking = true);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
    Task<TEntity> GetByIdAsync(int id, bool tracking = true);
}