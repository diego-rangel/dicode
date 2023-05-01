using Microsoft.EntityFrameworkCore;
using Modular.Domain.Core.Entities;

namespace Modular.EntityFramework.Core.Repositories;

public abstract class EfCoreRepository<TDbContext, TEntity, TKey> : 
    IEfCoreRepository<TDbContext, TEntity, TKey>
    where TEntity : Entity<TKey>
    where TDbContext : DbContext
{
    public TDbContext Context { get; }
    public DbSet<TEntity> DbSet => Context.Set<TEntity>();
    public virtual IQueryable<TEntity> Queryable => DbSet.AsQueryable();

    protected EfCoreRepository(TDbContext context)
    {
        Context = context;
    }
}

public abstract class EfCoreRepository<TDbContext, TEntity> : 
    EfCoreRepository<TDbContext, TEntity, Guid>
    where TEntity : Entity<Guid>
    where TDbContext : DbContext
{
    protected EfCoreRepository(TDbContext context) : base(context)
    {
    }
}