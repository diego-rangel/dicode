using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing.Contracts
{
    /// <summary>
    /// Defines an audited entity. It's primary key may not be "Id" or it may have a composite primary key.
    /// Use <see cref="IAudited{TEntityPrimaryKey, TUser, TUserKey}"/> where possible for better integration to repositories and other structures in the framework.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IAudited<TUser, TUserKey> : 
        ICreationAudited<TUser, TUserKey>, 
        IModificationAudited<TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {

    }

    /// <summary>
    /// Defines an audited entity with a single primary key with "Id" property.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IAudited<out TEntityPrimaryKey, TUser, TUserKey> :
        IAudited<TUser, TUserKey>,
        ICreationAudited<TEntityPrimaryKey, TUser, TUserKey>, 
        IModificationAudited<TEntityPrimaryKey, TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {

    }
}