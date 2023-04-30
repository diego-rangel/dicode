namespace DiCode.Domain.Core.Auditing.Contracts;

public interface IMayHaveModifier<TModifierKey>
{
    /// <summary>
    /// Id of the modifier user of this entity.
    /// </summary>
    TModifierKey? ModifierId { get; set; }
}

public interface IMayHaveModifier : IMayHaveModifier<Guid>
{

}