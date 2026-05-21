using Microsoft.Extensions.DependencyInjection;
using TgWsProxy.Routing.Interfaces;
using TgWsProxy.Routing.Models;
using TgWsProxy.Routing.Services;

namespace TgWsProxy.Routing.Extensions;

public static class RoutingServiceExtensions
{
    public static IServiceCollection AddRouting(
        this IServiceCollection services,
        Action<RoutingOptions>? configure = null
        )
    {
        if (configure != null)
        {
            services.Configure(configure);
        }
        else
        {
            services.Configure<RoutingOptions>(options => { });
        }

        services.AddSingleton<ITrafficRouter, TrafficRouter>();

        return services;
    }
}