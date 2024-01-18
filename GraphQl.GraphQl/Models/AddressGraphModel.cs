using GraphQl.Domain;
using GraphQL.Types;

namespace GraphQl.GraphQl.Models;

public class AddressGraphModel : ObjectGraphType<Address>
{
    public AddressGraphModel()
    {
        Name = "Address";
        Description = "A Location's address";
        Field(x => x.Street).Description("The street name and number.");
        Field(x => x.City).Description("The city.");
        Field(x => x.State).Description("The state.");
        Field(x => x.ZipCode).Description("The zip code.");
    }
}