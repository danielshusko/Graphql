using GraphQl.Domain.Models;
using GraphQl.GraphQl.Domain.DataLoaders;

// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl.Domain.Models;

public class CarGraphModel(Car car)
{
    public int Id { get; } = car.Id;
    public string Name { get; } = car.Name;
    public int ManufacturerId { get; } = car.ManufacturerId;

    public async Task<ManufacturerGraphModel?> Manufacturer([Service] ManufacturerBatchDataLoader dataLoader)
    {
        var manufacturer = await dataLoader.LoadAsync(ManufacturerId);
        return new ManufacturerGraphModel(manufacturer!);
    }
}