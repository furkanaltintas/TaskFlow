using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Repositories;

public interface IRepository<TEntity> : IQuery<TEntity>
    where TEntity : Entity
{
    DbSet<TEntity> Table { get; }
}