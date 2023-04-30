namespace DiCode.Domain.Core.Auditing.Contracts;

public interface IMayHaveModifierUser<TModifier>
{
    /// <summary>
    /// Reference to the modifier user of this entity.
    /// </summary>
    TModifier ModifierUser { get; set; }
}