using DiCode.Domain.Core.Entities;

namespace DiCode.Domain.Core.Repositories
{
    public interface IUpdatableRepository<TEntity, in TPrimaryKey> : IRepositoryBase
        where TEntity : IEntity<TPrimaryKey>
    {
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }

    public interface IUpdatableRepository<TEntity> : IUpdatableRepository<TEntity, Guid>
        where TEntity : IEntity<Guid>
    {

    }
}