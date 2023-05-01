using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Repositories;

public interface IRepository<TEntity, in TPrimaryKey> :
    IReadableRepository<TEntity, TPrimaryKey>,
    ICreatableRepository<TEntity, TPrimaryKey>,
    IUpdatableRepository<TEntity, TPrimaryKey>,
    IDeletableRepository<TEntity, TPrimaryKey>
    where TEntity : IEntity<TPrimaryKey>
{

}

public interface IRepository<TEntity> : IRepository<TEntity, Guid>
    where TEntity : IEntity<Guid>
{

}