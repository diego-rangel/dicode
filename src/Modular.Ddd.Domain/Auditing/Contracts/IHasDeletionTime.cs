using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing.Contracts
{
    /// <summary>
    /// An entity can implement this interface if <see cref="DeletionTime"/> of this entity must be stored.
    /// <see cref="DeletionTime"/> is automatically set when deleting <see cref="Entity"/>.
    /// </summary>
    public interface IHasDeletionTime
    {
        /// <summary>
        /// Deletion time of this entity.
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}