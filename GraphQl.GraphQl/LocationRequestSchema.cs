using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.GraphQl;

public class LocationRequestSchema : Schema
{
    public LocationRequestSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Description = "The Location domain schema.";
        Query = serviceProvider.GetRequiredService<LocationQuery>();
    }
}