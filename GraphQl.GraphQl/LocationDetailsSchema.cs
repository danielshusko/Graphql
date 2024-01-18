using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.GraphQl;

public class LocationDetailsSchema : Schema
{
    public LocationDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Description = "LocationService";
        Query = serviceProvider.GetRequiredService<LocationQuery>();
    }
}