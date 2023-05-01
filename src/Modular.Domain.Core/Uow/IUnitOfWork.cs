namespace Modular.Domain.Core.Uow;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<T> RunAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
}