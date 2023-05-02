using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Extensions;
using Modular.Ddd.Domain.Auditing;
using Modular.Ddd.Domain.Auditing.Contracts;
using System.Reflection;
using Modular.Core.Users;
using Modular.Ddd.Domain.Services;

namespace Modular.Ddd.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection DiscoverDddDomainServicesFromAssembly(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.RegisterWhoImplements(typeof(IDomainService), assemblies);

        return services;
    }

    public static IServiceCollection AddModularDddUserAudit<TUserKey, TCurrentUser>(this IServiceCollection services)
    where TCurrentUser : class, ICurrentUser<TUserKey>
    {
        services.AddScoped<IAuditPropertySetter, AuditPropertySetter<TUserKey>>();
        services.AddScoped<ICurrentUser<TUserKey>, TCurrentUser>();

        return services;
    }
}