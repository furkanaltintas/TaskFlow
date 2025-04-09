using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class WriteRepository<TEntity> : IWriteRepository<TEntity>
    where TEntity : Entity
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task<bool> AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<TEntity> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }

    public IQueryable<TEntity> Query() => Table.AsQueryable();

    public bool Remove(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        TEntity? model = await Table.FirstOrDefaultAsync(data => data.Id == id);
        return Remove(model!);
    }

    public bool RemoveRange(List<TEntity> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public bool Update(TEntity entity)
    {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
}
