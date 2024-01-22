using GraphQl.GraphQl.Domain;
using GraphQl.GraphQl.Domain.DataLoaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.GraphQl;

public static class DependencyInjection
{
    public static IServiceCollection AddGraphQlProject(this IServiceCollection services)
    {
        services.AddScoped<PersonBatchDataLoader>();
        services.AddScoped<PersonGroupDataLoader>();
        services.AddScoped<CarBatchDataLoader>();
        services.AddScoped<ManufacturerBatchDataLoader>();

        services.AddGraphQLServer()
            .AddQueryType<PersonQueries>()
            .AddErrorFilter<GraphQlErrorFilter>()
            .AddFiltering();

        return services;
    }

    public static WebApplication AddGraphQlProject(this WebApplication app)
    {
        app.MapGraphQL();

        return app;
    }
}