﻿using DiCode.Domain.Core.Repositories;
using DiCode.Domain.Core.Uow;
using DiCode.EntityFramework.Core.Repositories;
using DiCode.EntityFramework.Core.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiCode.EntityFramework.Extensions;

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