using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing.Contracts
{
    /// <summary>
    /// A shortcut of <see cref="ICreationAudited{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public interface ICreationAudited : 
        ICreationAudited<Guid, Guid>
    {

    }

    /// <summary>
    /// This interface is implemented by entities that is wanted to store creation information (who and when created).
    /// Creation time and creator user are automatically set when saving <see cref="Entity"/> to database.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public interface ICreationAudited<out TEntityPrimaryKey, TUserKey> : 
        IEntity<TEntityPrimaryKey>,
        IMustHaveCreator<TUserKey>,
        IHasCreationTime
        where TUserKey : struct
    {
        
    }

    /// <summary>
    /// Adds navigation properties to <see cref="ICreationAudited{TUser,TUserKey}"/> interface for user.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface ICreationAudited<out TEntityPrimaryKey, TUserKey, TUser> : 
        ICreationAudited<TEntityPrimaryKey, TUserKey>,
        IMustHaveCreatorUser<TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        
    }
}