using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Modular.Domain.Core.Auditing.Contracts;
using Modular.Domain.Core.Entities;
using Modular.Domain.Core.Repositories;

namespace Modular.EntityFramework.Core.Repositories;

public class Repository<TDbContext, TEntity, TKey> :
    EfCoreRepository<TDbContext, TEntity, TKey>,
    IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TDbContext : DbContext
{
    public Repository(TDbContext context) : base(context)
    {
    }

    public override IQueryable<TEntity> Queryable
    {
        get
        {
            var query = DbSet.AsQueryable();

            if (typeof(IHasDeletionTime).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(x => ((IHasDeletionTime)x).DeletionTime.HasValue == false);
            }

            return query;
        }
    }

    public virtual async Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await Queryable.FirstOrDefaultAsync(x => x.Id!.Equals(id), cancellationToken);
    }

    public virtual async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<List<TEntity>> FindAsync(CancellationToken cancellationToken = default)
    {
        return await Queryable.ToListAsync(cancellationToken);
    }

    public virtual async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Queryable.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await Queryable.CountAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Queryable.CountAsync(predicate, cancellationToken);
    }

    public virtual Task<IQueryable<TEntity>> QueryAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Queryable.AsNoTracking());
    }

    public virtual Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Queryable.Where(predicate).AsNoTracking());
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var savedEntity = (await DbSet.AddAsync(entity, cancellationToken)).Entity;
        return savedEntity;
    }

    public virtual async Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
    }

    public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var savedEntity = DbSet.Update(entity).Entity;
        return Task.FromResult(savedEntity);
    }

    public virtual Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DbSet.UpdateRange(entities);
        return Task.CompletedTask;
    }

    public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await FindAsync(id, cancellationToken);
        if (entity == null) return false;
        return await DeleteAsync(entity, cancellationToken);
    }

    public virtual Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public virtual Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entities = await FindAsync(predicate, cancellationToken);
        await DeleteManyAsync(entities, cancellationToken);
    }
}

public abstract class Repository<TDbContext, TEntity> :
    Repository<TDbContext, TEntity, Guid>
    where TEntity : Entity<Guid>
    where TDbContext : DbContext
{
    protected Repository(TDbContext context) : base(context)
    {
    }
}