using Microsoft.EntityFrameworkCore;
using Modular.Ddd.Domain.Entities;

namespace Modular.EntityFramework.Core.Repositories;

public interface IEfCoreRepository<out TDbContext, TEntity, in TKey>
    where TEntity : Entity<TKey>
    where TDbContext : DbContext
{
    TDbContext Context { get; }
    DbSet<TEntity> DbSet { get; }
    IQueryable<TEntity> Queryable { get; }
}