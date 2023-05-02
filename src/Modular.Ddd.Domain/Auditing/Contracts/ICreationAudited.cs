using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing.Contracts
{
    /// <summary>
    /// Defines a creation audited entity. It's primary key may not be "Id" or it may have a composite primary key.
    /// Use <see cref="ICreationAudited{TEntityPrimaryKey, TUser, TUserKey}"/> where possible for better integration to repositories and other structures in the framework.
    /// </summary>
    public interface ICreationAudited<TUser, TUserKey> :
        IEntity,
        IHasCreationTime, 
        IMustHaveCreator<TUserKey>,
        IMustHaveCreatorUser<TUser>
        where TUser : IEntity<TUserKey>
    {

    }

    /// <summary>
    /// Defines a creation audited entity with a single primary key with "Id" property.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">Type of the primary key of the entity</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface ICreationAudited<out TEntityPrimaryKey, TUser, TUserKey> :
        ICreationAudited<TUser, TUserKey>,
        IEntity<TEntityPrimaryKey>
        where TUser : IEntity<TUserKey>
    {

    }
}