using GraphQl.Domain;
using GraphQl.Grpc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<LocationService>();

builder.Services
    .AddGrpcReflection()
    .AddGrpc()
    .AddJsonTranscoding();


var app = builder.Build();

app.UseHttpsRedirection();
app.MapGrpcService<LocationGrpcService>();
app.MapGrpcReflectionService();
app.MapGrpcHealthChecksService();

app.Run();
