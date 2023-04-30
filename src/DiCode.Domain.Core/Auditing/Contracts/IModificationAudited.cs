using DiCode.Domain.Core.Entities;

namespace DiCode.Domain.Core.Auditing.Contracts
{
    /// <summary>
    /// A shortcut of <see cref="IModificationAudited{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public interface IModificationAudited : 
        IModificationAudited<Guid, Guid>
    {

    }

    /// <summary>
    /// This interface is implemented by entities that is wanted to store modification information (who and when modified lastly).
    /// Properties are automatically set when updating the <see cref="IEntity"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IModificationAudited<out TEntityPrimaryKey, TUserKey> : 
        IEntity<TEntityPrimaryKey>,
        IMayHaveModifier<TUserKey>,
        IHasModificationTime
        where TUserKey : struct
    {
        
    }

    /// <summary>
    /// Adds navigation properties to <see cref="IModificationAudited{TUser,TUserKey}"/> interface for user.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IModificationAudited<out TEntityPrimaryKey, TUserKey, TUser> : 
        IModificationAudited<TEntityPrimaryKey, TUserKey>,
        IMayHaveModifierUser<TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        
    }
}