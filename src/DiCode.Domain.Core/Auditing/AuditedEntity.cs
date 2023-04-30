using DiCode.Domain.Core.Auditing.Contracts;
using DiCode.Domain.Core.Entities;

namespace DiCode.Domain.Core.Auditing
{
    /// <summary>
    /// A shortcut of <see cref="AuditedEntity{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public abstract class AuditedEntity : AuditedEntity<Guid, Guid>
    {

    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAudited"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class AuditedEntity<TEntityPrimaryKey, TUserKey> : 
        CreationAuditedEntity<TEntityPrimaryKey, TUserKey>, 
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
    public abstract class AuditedEntity<TEntityPrimaryKey, TUserKey, TUser> : 
        AuditedEntity<TEntityPrimaryKey, TUserKey>,
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