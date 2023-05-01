using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Domain.Core.Repositories;
using Modular.Domain.Core.Uow;
using Modular.EntityFramework.Core.Repositories;
using Modular.EntityFramework.Core.Uow;

namespace Modular.EntityFramework.Extensions;

public static class DependencyInjection
{
    public static void AddDbContext<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        where TContext : DbContext
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
        services.AddTransient(typeof(IRepository<>), typeof(Repository<,>));
        services.AddTransient(typeof(IRepository<,>), typeof(Repository<,,>));
        services.AddPooledDbContextFactory<TContext>(optionsAction);
        services.AddDbContextPool<TContext>(optionsAction);
    }
}