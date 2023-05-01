using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Repositories
{
    public interface ICreatableRepository<TEntity, in TPrimaryKey> : IRepositoryBase
        where TEntity : IEntity<TPrimaryKey>
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }

    public interface ICreatableRepository<TEntity> : ICreatableRepository<TEntity, Guid>
        where TEntity : IEntity<Guid>
    {

    }
}