using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Extensions;

namespace Modular.Ddd.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection DiscoverDddApplicationServicesFromAssembly(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.RegisterWhoImplements(typeof(IApplicationService), assemblies);

        return services;
    }
}