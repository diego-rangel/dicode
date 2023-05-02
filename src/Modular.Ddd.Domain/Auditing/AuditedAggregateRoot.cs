using Modular.Ddd.Domain.Auditing.Contracts;
using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAudited{TUserKey, TUser}"/>.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class AuditedAggregateRoot<TUser, TUserKey> :
        CreationAuditedAggregateRoot<TUser, TUserKey>,
        IAudited<TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {
        /// <inheritdoc/>
        public DateTime? LastModificationTime { get; set; }

        /// <inheritdoc/>
        public TUserKey? ModifierId { get; set; }

        /// <inheritdoc/>
        public TUser ModifierUser { get; set; } = default!;
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAudited{TEntityPrimaryKey, TUserKey, TUser}"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class AuditedAggregateRoot<TEntityPrimaryKey, TUser, TUserKey> :
        CreationAuditedAggregateRoot<TEntityPrimaryKey, TUser, TUserKey>,
        IAudited<TEntityPrimaryKey, TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {
        /// <inheritdoc/>
        public DateTime? LastModificationTime { get; set; }

        /// <inheritdoc/>
        public TUserKey? ModifierId { get; set; }

        /// <inheritdoc/>
        public TUser ModifierUser { get; set; } = default!;
    }
}