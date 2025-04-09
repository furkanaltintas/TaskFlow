using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWorks;
using Domain.Common;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) { _context = context; }


    public ValueTask DisposeAsync() => _context.DisposeAsync();

    public int Save() => _context.SaveChanges();
    public Task<int> SaveAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);


    public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : Entity
        => new ReadRepository<TEntity>(_context);

    public IWriteRepository<TEntity> WriteRepository<TEntity>() where TEntity : Entity
        => new WriteRepository<TEntity>(_context);
}