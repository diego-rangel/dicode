using DiCode.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiCode.EntityFramework.Core.Repositories;

public interface IEfCoreRepository<out TDbContext, TEntity, in TKey>
    where TEntity : Entity<TKey>
    where TDbContext : DbContext
{
    TDbContext Context { get; }
    DbSet<TEntity> DbSet { get; }
    IQueryable<TEntity> Queryable { get; }
}