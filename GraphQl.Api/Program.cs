using GraphQl.Domain;
using GraphQl.GraphQl;
using GraphQl.Grpc;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDomainProject()
    .AddGrpcProject()
    .AddGraphQlProject();

var app = builder.Build();
app.UseHttpsRedirection();
app
    .AddGrpcProject()
    .AddGraphQlProject();
app.Run();