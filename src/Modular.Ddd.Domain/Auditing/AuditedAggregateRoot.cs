using Modular.Ddd.Domain.Auditing.Contracts;
using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing
{
    /// <summary>
    /// A shortcut of <see cref="AuditedAggregateRoot{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public abstract class AuditedAggregateRoot : AuditedAggregateRoot<Guid, Guid>
    {

    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAudited"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class AuditedAggregateRoot<TEntityPrimaryKey, TUserKey> :
        CreationAuditedAggregateRoot<TEntityPrimaryKey, TUserKey>, 
        IAudited<TEntityPrimaryKey, TUserKey>
        where TUserKey : struct
    {
        /// <inheritdoc/>
        public TUserKey ModifierId { get; set; }

        /// <inheritdoc/>
        public DateTime? LastModificationTime { get; set; }
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAudited{TEntityPrimaryKey, TUserKey, TUser}"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public abstract class AuditedAggregateRoot<TEntityPrimaryKey, TUserKey, TUser> :
        AuditedAggregateRoot<TEntityPrimaryKey, TUserKey>,
        IAudited<TEntityPrimaryKey, TUserKey, TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        /// <inheritdoc/>
        public TUser CreatorUser { get; set; } = default!;

        /// <inheritdoc/>
        public TUser ModifierUser { get; set; } = default!;
    }
}