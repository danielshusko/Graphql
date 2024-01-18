using GraphQl.Domain;
using GraphQL.Types;

// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl.Models;

public class LocationGraphModel : ObjectGraphType<Location>
{
    public LocationGraphModel()
    {
        Name = "Location";
        Description = "A US landmark location.";
        Field(x => x.Id).Description("The Location's global id.");
        Field(x => x.Code).Description("A user friendly unique code.");
        Field(x => x.Name).Description("The Location's name.");
        Field(x => x.Address, type: typeof(AddressGraphModel)).Description("The Location's address.");
    }
}