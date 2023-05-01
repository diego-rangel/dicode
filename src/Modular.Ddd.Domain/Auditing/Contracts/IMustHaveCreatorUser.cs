namespace Modular.Ddd.Domain.Auditing.Contracts;

public interface IMustHaveCreatorUser<TCreator>
{
    /// <summary>
    /// Reference to the creator user of this entity.
    /// </summary>
    TCreator CreatorUser { get; set; }
}