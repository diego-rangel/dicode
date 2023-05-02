using Microsoft.EntityFrameworkCore;
using Modular.Core.Uow;

namespace Modular.EntityFramework.Core.Uow;

public class UnitOfWork<TDbContext> :
    IUnitOfWork
    where TDbContext : DbContext
{
    private readonly TDbContext _context;
    public UnitOfWork(TDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> RunAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default)
    {
        await using var tran = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var result = await action();
            await tran.CommitAsync(cancellationToken);
            return result;
        }
        catch (Exception)
        {
            await tran.RollbackAsync(cancellationToken);
            throw;
        }
    }
}