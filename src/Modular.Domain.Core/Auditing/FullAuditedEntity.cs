using Modular.Domain.Core.Auditing.Contracts;
using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Auditing
{
    /// <summary>
    /// A shortcut of <see cref="FullAuditedEntity{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public abstract class FullAuditedEntity : FullAuditedEntity<Guid, Guid>
    {
        
    }

    /// <summary>
    /// Implements <see cref="IFullAudited"/> to be a base class for full-audited entities.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class FullAuditedEntity<TEntityPrimaryKey, TUserKey> : 
        AuditedEntity<TEntityPrimaryKey, TUserKey>, 
        IFullAudited<TEntityPrimaryKey, TUserKey>
        where TUserKey : struct
    {
        /// <inheritdoc/>
        public TUserKey DeleterId { get; set; }

        /// <inheritdoc/>
        public DateTime? DeletionTime { get; set; }
    }

    /// <summary>
    /// Implements <see cref="IFullAudited{TEntityPrimaryKey, TUserKey, TUser}"/> to be a base class for full-audited entities.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public abstract class FullAuditedEntity<TEntityPrimaryKey, TUserKey, TUser> : 
        FullAuditedEntity<TEntityPrimaryKey, TUserKey>, 
        IFullAudited<TEntityPrimaryKey, TUserKey, TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        /// <inheritdoc/>
        public TUser CreatorUser { get; set; } = default!;

        /// <inheritdoc/>
        public TUser ModifierUser { get; set; } = default!;

        /// <inheritdoc/>
        public TUser DeleterUser { get; set; } = default!;
    }
}