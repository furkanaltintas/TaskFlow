using Application.Interfaces.Repositories;
using Domain.Common;

namespace Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : Entity;
    IWriteRepository<TEntity> WriteRepository<TEntity>() where TEntity : Entity;

    int Save();
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}