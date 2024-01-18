using GraphQl.Domain;
using GraphQl.Grpc;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDomainProject()
    .AddGrpcProject();

var app = builder.Build();
app.UseHttpsRedirection();
app.AddGrpcProject();
app.Run();