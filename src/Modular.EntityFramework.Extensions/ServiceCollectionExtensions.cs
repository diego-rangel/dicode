using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Uow;
using Modular.Ddd.Domain.Repositories;
using Modular.EntityFramework.Core.Uow;
using System.Reflection;
using Modular.Core.Extensions;

namespace Modular.EntityFramework.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModularDbContext<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        where TContext : DbContext
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
        services.AddPooledDbContextFactory<TContext>(optionsAction);
        services.AddDbContextPool<TContext>(optionsAction);

        return services;
    }

    public static IServiceCollection DiscoverRepositoriesFromAssembly(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.RegisterWhoImplements(typeof(IRepositoryBase), assemblies);

        return services;
    }
}