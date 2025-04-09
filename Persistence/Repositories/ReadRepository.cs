using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : Entity
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Query();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<TEntity> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Query();
            if (!tracking)
                query = Table.AsNoTracking();

            TEntity? entity = await query.FirstOrDefaultAsync(data => data.Id == id);
            if (entity is null) throw new Exception("Data not found");
            return entity;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Query();
            if (!tracking)
                query = Table.AsNoTracking();

            TEntity? entity = await query.FirstOrDefaultAsync(method);
            if(entity is null) throw new Exception("Data not found");

            return entity;
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)

                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<TEntity> Query() => Table.AsQueryable();
    }
}
