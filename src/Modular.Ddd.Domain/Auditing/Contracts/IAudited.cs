using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing.Contracts
{

    /// <summary>
    /// A shortcut of <see cref="IAudited{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public interface IAudited : IAudited<Guid, Guid>
    {

    }

    /// <summary>
    /// This interface is implemented by entities which must be audited.
    /// Related properties automatically set when saving/updating <see cref="Entity"/> objects.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface IAudited<out TEntityPrimaryKey, TUserKey> : 
        ICreationAudited<TEntityPrimaryKey, TUserKey>, 
        IModificationAudited<TEntityPrimaryKey, TUserKey>
        where TUserKey : struct
    {

    }

    /// <summary>
    /// Adds navigation properties to <see cref="IAudited{TUser,TUserKey}"/> interface for user.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IAudited<out TEntityPrimaryKey, TUserKey, TUser> : 
        IAudited<TEntityPrimaryKey, TUserKey>, 
        ICreationAudited<TEntityPrimaryKey, TUserKey, TUser>, 
        IModificationAudited<TEntityPrimaryKey, TUserKey, TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {

    }
}