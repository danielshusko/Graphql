namespace GraphQl.Domain.Models;

public class Car(int id, string name, int manufactureId)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public int ManufacturerId { get; } = manufactureId;

    public Manufacturer Manufacturer { get; } = null!;
}