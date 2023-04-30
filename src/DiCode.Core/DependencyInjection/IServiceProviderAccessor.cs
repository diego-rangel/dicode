namespace DiCode.Core.DependencyInjection;

public interface IServiceProviderAccessor
{
    IServiceProvider ServiceProvider { get; }
}