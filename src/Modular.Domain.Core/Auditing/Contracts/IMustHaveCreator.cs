namespace Modular.Domain.Core.Auditing.Contracts;

public interface IMustHaveCreator<TCreatorKey>
{
    /// <summary>
    /// Id of the creator user of this entity.
    /// </summary>
    TCreatorKey CreatorId { get; set; }
}

public interface IMustHaveCreator : IMustHaveCreator<Guid>
{
    
}