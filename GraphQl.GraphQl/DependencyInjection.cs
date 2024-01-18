using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.GraphQl;

public static class DependencyInjection
{
    public static IServiceCollection AddGraphQlProject(this IServiceCollection services)
    {
        services.AddScoped<LocationGraphQlDto>();
        services.AddScoped<AddressGraphQlDto>();

        services.AddScoped<LocationQuery>();
        services.AddScoped<ISchema, LocationDetailsSchema>();
        
        services.AddGraphQL(b => b
            .AddAutoSchema<LocationQuery>() // schema
            .AddSystemTextJson() // serializer
            .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
        ); 
        return services;
    }
    public static WebApplication AddGraphQlProject(this WebApplication app)
    {
        app.UseGraphQL<ISchema>("/graphql");            // url to host GraphQL endpoint
        app.UseGraphQLPlayground(
            "/playground",                               // url to host Playground at
            new GraphQL.Server.Ui.Playground.PlaygroundOptions
            {
                GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
                SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
            });

        return app;
    }
}