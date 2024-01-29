using Microsoft.Extensions.DependencyInjection;

namespace TuneTalk.Core;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        return services;
    }
}