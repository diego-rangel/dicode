using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Repositories
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