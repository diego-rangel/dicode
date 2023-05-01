using Modular.Core.Extensions;

namespace Modular.Ddd.Domain.Entities;

/// <inheritdoc/>
public abstract class Entity : IEntity
{
    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Keys = {GetKeys().JoinAsString(", ")}";
    }

    public abstract object[] GetKeys();

    public bool EntityEquals(IEntity other)
    {
        return EntityHelper.EntityEquals(this, other);
    }
}

/// <inheritdoc cref="IEntity{TKey}" />
public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    /// <inheritdoc/>
    public TKey Id { get; protected set; } = default!;

    protected Entity()
    {

    }
    protected Entity(TKey id)
    {
        Id = id;
    }

    public override object[] GetKeys()
    {
        return Id != null ? new object[] { Id } : Array.Empty<object>();
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Id = {Id}";
    }
}