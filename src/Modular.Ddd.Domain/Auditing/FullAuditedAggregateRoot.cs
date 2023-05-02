using Modular.Ddd.Domain.Auditing.Contracts;
using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing
{
    /// <summary>
    /// Implements <see cref="IFullAudited{TUser,TUserKey}"/> to be a base class for full-audited entities.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class FullAuditedAggregateRoot<TUser, TUserKey> :
        AuditedAggregateRoot<TUser, TUserKey>,
        IFullAudited<TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {
        /// <inheritdoc/>
        public DateTime? DeletionTime { get; set; }

        /// <inheritdoc/>
        public TUserKey? DeleterId { get; set; }

        /// <inheritdoc/>
        public TUser DeleterUser { get; set; } = default!;
    }

    /// <summary>
    /// Implements <see cref="IFullAudited{TEntityPrimaryKey, TUserKey, TUser}"/> to be a base class for full-audited entities.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class FullAuditedAggregateRoot<TEntityPrimaryKey, TUser, TUserKey> :
        AuditedAggregateRoot<TEntityPrimaryKey, TUser, TUserKey>,
        IFullAudited<TEntityPrimaryKey, TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {
        /// <inheritdoc/>
        public DateTime? DeletionTime { get; set; }

        /// <inheritdoc/>
        public TUserKey? DeleterId { get; set; }

        /// <inheritdoc/>
        public TUser DeleterUser { get; set; } = default!;
    }
}