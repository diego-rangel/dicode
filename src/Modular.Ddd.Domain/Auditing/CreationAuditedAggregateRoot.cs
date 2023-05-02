using Modular.Ddd.Domain.Auditing.Contracts;
using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAudited{TUser,TUserKey}"/>.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class CreationAuditedAggregateRoot<TUser, TUserKey> :
        AggregateRoot,
        ICreationAudited<TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {
        /// <inheritdoc/>
        public DateTime CreationTime { get; set; }

        /// <inheritdoc/>
        public TUserKey CreatorId { get; set; } = default!;

        /// <inheritdoc/>
        public TUser CreatorUser { get; set; } = default!;
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAudited{TEntityPrimaryKey, TUserKey, TUser}"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class CreationAuditedAggregateRoot<TEntityPrimaryKey, TUser, TUserKey> :
        AggregateRoot<TEntityPrimaryKey>,
        ICreationAudited<TEntityPrimaryKey, TUser, TUserKey>
        where TUser : IEntity<TUserKey>
    {
        /// <inheritdoc/>
        public DateTime CreationTime { get; set; }

        /// <inheritdoc/>
        public TUserKey CreatorId { get; set; } = default!;

        /// <inheritdoc/>
        public TUser CreatorUser { get; set; } = default!;
    }
}