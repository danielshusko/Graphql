using GraphQL.Types;
using GraphQL;
using GraphQl.Domain;

namespace GraphQl.GraphQl
{
    public class LocationQuery : ObjectGraphType
    {
        public LocationQuery(LocationService locationService)
        {
            Field<ListGraphType<LocationGraphQlDto>>(
                Name = "Locations",
                Description = "Gets all locations.",
                resolve: x => locationService.GetLocations()
            );

            Field<ListGraphType<LocationGraphQlDto>>(
                Name = "Location",
                Description = "Gets a location by its id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: x =>
                {
                    var location = locationService.GetById(x.GetArgument<int>("id"));
                    return new[]{location};
                });
        }
    }
}
