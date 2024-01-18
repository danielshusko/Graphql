using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainProject(this IServiceCollection services)
    {
        services.AddScoped<LocationService>();
        return services;
    }
}