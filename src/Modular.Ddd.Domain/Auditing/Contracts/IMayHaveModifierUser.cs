namespace Modular.Ddd.Domain.Auditing.Contracts;

public interface IMayHaveModifierUser<TModifier>
{
    /// <summary>
    /// Reference to the modifier user of this entity.
    /// </summary>
    TModifier ModifierUser { get; set; }
}