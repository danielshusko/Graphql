namespace GraphQl.Domain.Models;

public class Manufacturer(int id, string name, string country)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public string Country { get; } = country;
}