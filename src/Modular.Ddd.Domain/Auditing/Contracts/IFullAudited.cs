using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing.Contracts
{
    /// <summary>
    /// Defines a full audited entity. It's primary key may not be "Id" or it may have a composite primary key.
    /// Use <see cref="IFullAudited{TEntityPrimaryKey, TUser, TUserKey}"/> where possible for better integration to repositories and other structures in the framework.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IFullAudited<TUser, TUserKey> : 
        IAudited<TUser, TUserKey>, 
        IDeletionAudited<TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {

    }

    /// <summary>
    /// Defines a full audited entity with a single primary key with "Id" property.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IFullAudited<out TEntityPrimaryKey, TUser, TUserKey> :
        IFullAudited<TUser, TUserKey>,
        IAudited<TEntityPrimaryKey, TUser, TUserKey>, 
        IDeletionAudited<TEntityPrimaryKey, TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {

    }
}