using GraphQL;
using GraphQl.Domain;
using GraphQl.GraphQl.Models;
using GraphQL.Types;

// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl;

public class LocationQuery : ObjectGraphType
{
    public LocationQuery(LocationService locationService)
    {
        Name = "LocationQuery";
        Description = "Methods to interact with the Location domain.";

        Field<ListGraphType<LocationGraphModel>>("GetLocations")
            .Description("Gets all locations.")
            .Resolve(x => locationService.GetLocations());

        Field<LocationGraphModel>("GetLocationById")
            .Description("Gets a location by its id")
            .Argument<IntGraphType>("id")
            .Resolve(x => locationService.GetById(x.GetArgument<int>("id")));
    }
}