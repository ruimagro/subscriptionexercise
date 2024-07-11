using Crayon.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Crayon.Application;

public static class ConfigureDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<IServiceSubscription, ServiceSubscription>();
        services.AddMediatR(options =>
            options.RegisterServicesFromAssemblyContaining(typeof(ConfigureDependencyInjection))
        );
        return services;
    }
}