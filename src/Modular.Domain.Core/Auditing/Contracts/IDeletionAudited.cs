using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Auditing.Contracts
{
    /// <summary>
    /// A shortcut of <see cref="IDeletionAudited{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public interface IDeletionAudited : 
        IDeletionAudited<Guid, Guid>
    {

    }

    /// <summary>
    /// This interface is implemented by entities which wanted to store deletion information (who and when deleted).
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IDeletionAudited<out TEntityPrimaryKey, TUserKey> : 
        IEntity<TEntityPrimaryKey>,
        IMayHaveDeleter<TUserKey>,
        IHasDeletionTime
        where TUserKey : struct
    {
        
    }

    /// <summary>
    /// Adds navigation properties to <see cref="IDeletionAudited{TUser,TUserKey}"/> interface for user.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IDeletionAudited<out TEntityPrimaryKey, TUserKey, TUser> : 
        IDeletionAudited<TEntityPrimaryKey, TUserKey>,
        IMayHaveDeleterUser<TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        
    }
}