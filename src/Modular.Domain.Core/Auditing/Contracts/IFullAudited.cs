using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Auditing.Contracts
{
    /// <summary>
    /// A shortcut of <see cref="IFullAudited{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public interface IFullAudited : IFullAudited<Guid, Guid>
    {

    }

    /// <summary>
    /// This interface is implemented by entities which must be full audited.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IFullAudited<out TEntityPrimaryKey, TUserKey> : 
        IAudited<TEntityPrimaryKey, TUserKey>, 
        IDeletionAudited<TEntityPrimaryKey, TUserKey>
        where TUserKey : struct
    {

    }

    /// <summary>
    /// Adds navigation properties to <see cref="IFullAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IFullAudited<out TEntityPrimaryKey, TUserKey, TUser> : 
        IFullAudited<TEntityPrimaryKey, TUserKey>, 
        IAudited<TEntityPrimaryKey, TUserKey, TUser>, 
        IDeletionAudited<TEntityPrimaryKey, TUserKey, TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {

    }
}