using System.Linq.Expressions;
using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Repositories
{
    public interface IDeletableRepository<TEntity, in TPrimaryKey> : IRepositoryBase
        where TEntity : IEntity<TPrimaryKey>
    {
        Task<bool> DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }

    public interface IDeletableRepository<TEntity> : IDeletableRepository<TEntity, Guid>
        where TEntity : IEntity<Guid>
    {

    }
}