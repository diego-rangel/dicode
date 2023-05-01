namespace Modular.Domain.Core.Entities;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
}

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
{
    protected AggregateRoot()
    {

    }
    protected AggregateRoot(TKey id) : base(id)
    {
        
    }
}