using System.Linq.Expressions;
using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Repositories
{
    public interface IReadableRepository<TEntity, in TPrimaryKey> : 
        IRepositoryBase
        where TEntity : IEntity<TPrimaryKey>
    {
        Task<TEntity?> FindAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
        Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<TEntity>> FindAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> QueryAsync(CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }

    public interface IReadableRepository<TEntity> : IReadableRepository<TEntity, Guid>
        where TEntity : IEntity<Guid>
    {

    }
}