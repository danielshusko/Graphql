using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainProject(this IServiceCollection services)
    {
        services.AddScoped<PersonService>();
        services.AddScoped<CarService>();
        services.AddScoped<ManufacturerService>();
        return services;
    }
}