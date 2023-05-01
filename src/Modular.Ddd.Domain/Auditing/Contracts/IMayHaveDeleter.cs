namespace Modular.Ddd.Domain.Auditing.Contracts;

public interface IMayHaveDeleter<TDeleterKey>
{
    /// <summary>
    /// Id of the deleter user of this entity.
    /// </summary>
    TDeleterKey? DeleterId { get; set; }
}

public interface IMayHaveDeleter : IMayHaveDeleter<Guid>
{

}