using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Repositories
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