namespace DiCode.Core.Users;

public interface ICurrentUser<out TKey>
{
    TKey? Id { get; }
}

public interface ICurrentUser : ICurrentUser<Guid?>
{
    
}