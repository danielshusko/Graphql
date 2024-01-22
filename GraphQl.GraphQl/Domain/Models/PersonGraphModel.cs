using GraphQl.Domain.Models;
using GraphQl.GraphQl.Domain.DataLoaders;

// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl.Domain.Models;

public class PersonGraphModel(Person person)
{
    [GraphQLDescription("Person's id")] public int Id { get; } = person.Id;

    public string FirstName { get; } = person.FirstName;
    public string LastName { get; } = person.LastName;
    public int? MotherId { get; } = person.MotherId;
    public int? FatherId { get; } = person.FatherId;
    public int? CarId { get; } = person.CarId;

    public async Task<PersonGraphModel?> Mother([Service] PersonBatchDataLoader dataLoader)
    {
        if (MotherId == null) return null;

        var person = await dataLoader.LoadAsync(MotherId.Value);
        return new PersonGraphModel(person);
    }

    public async Task<PersonGraphModel?> Father([Service] PersonBatchDataLoader dataLoader)
    {
        if (FatherId == null) return null;

        var person = await dataLoader.LoadAsync(FatherId.Value);
        return new PersonGraphModel(person);
    }

    public async Task<List<PersonGraphModel>> Children([Service] PersonGroupDataLoader dataLoader)
    {
        var childrenGroups = await dataLoader.LoadAsync(Id);

        var children = childrenGroups
            .SelectMany(childrenGroup => childrenGroup.Select(child => new PersonGraphModel(child)))
            .ToList();
        return children;
    }

    public async Task<CarGraphModel?> Car([Service] CarBatchDataLoader dataLoader)
    {
        if (CarId == null) return null;

        var car = await dataLoader.LoadAsync(CarId.Value);
        return new CarGraphModel(car);
    }

    public string GetCursor() => this.GetHashCode().ToString();
}