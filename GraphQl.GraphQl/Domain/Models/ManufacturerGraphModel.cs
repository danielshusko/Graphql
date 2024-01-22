using GraphQl.Domain.Models;

namespace GraphQl.GraphQl.Domain.Models;

public class ManufacturerGraphModel(Manufacturer manufacturer)
{
    public int Id { get; } = manufacturer.Id;
    public string Name { get; } = manufacturer.Name;
    public string Country { get; } = manufacturer.Country;
}