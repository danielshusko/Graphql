using GraphQL;
using GraphQl.GraphQl.Models;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.GraphQl;

public static class DependencyInjection
{
    public static IServiceCollection AddGraphQlProject(this IServiceCollection services)
    {
        services.AddScoped<LocationGraphModel>();
        services.AddScoped<AddressGraphModel>();

        services.AddScoped<LocationQuery>();
        services.AddScoped<ISchema, LocationRequestSchema>();

        services.AddGraphQL(b => b
            .AddAutoSchema<LocationQuery>()
            .AddSystemTextJson()
            .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
        );
        return services;
    }

    public static WebApplication AddGraphQlProject(this WebApplication app)
    {
        app.UseGraphQL<ISchema>();

        //This adds an endpoint that lets us test the graphql. this should not be used in prod
        app.UseGraphQLPlayground(
            "/playground",
            new PlaygroundOptions
            {
                GraphQLEndPoint = "/graphql",
                SubscriptionsEndPoint = "/graphql"
            });

        return app;
    }
}