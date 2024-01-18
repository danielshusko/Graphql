using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Grpc;

public static class DependencyInjection
{
    public static IServiceCollection AddGrpcProject(this IServiceCollection services)
    {
        services
            .AddGrpcReflection()
            .AddGrpc()
            .AddJsonTranscoding();

        return services;
    }

    public static WebApplication AddGrpcProject(this WebApplication app)
    {
        app.MapGrpcService<LocationGrpcService>();
        app.MapGrpcReflectionService();
        app.MapGrpcHealthChecksService();

        return app;
    }
}