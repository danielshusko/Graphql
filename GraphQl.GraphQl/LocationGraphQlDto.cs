using GraphQl.Domain;
using GraphQL.Types;
// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl;

public class LocationGraphQlDto : ObjectGraphType<Location>
{
    public LocationGraphQlDto()
    {
        Name = "LocationModel";
        Description = "A US landmark location.";
        Field(x => x.Id).Description("The Location's global id.");
        Field(x => x.Code).Description("A user friendly unique code.");
        Field(x => x.Name).Description("The Location's name.");
        Field(x => x.Address, type:typeof(AddressGraphQlDto)).Description("The Location's address.");
    }
}

public class AddressGraphQlDto : ObjectGraphType<Address>
{
    public AddressGraphQlDto()
    {
        Name = "AddressModel";
        Description = "A Location's address";
        Field(x => x.Street).Description("The street name and number.");
        Field(x => x.City).Description("The city.");
        Field(x => x.State).Description("The state.");
        Field(x => x.ZipCode).Description("The zip code.");
    }
}