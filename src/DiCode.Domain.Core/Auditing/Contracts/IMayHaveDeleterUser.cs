namespace DiCode.Domain.Core.Auditing.Contracts;

public interface IMayHaveDeleterUser<TDeleter>
{
    /// <summary>
    /// Reference to the deleter user of this entity.
    /// </summary>
    TDeleter DeleterUser { get; set; }
}