using GraphQl.Domain;
using GraphQl.GraphQl.Domain.DataLoaders;
using GraphQl.GraphQl.Domain.Models;


// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl.Domain;

public class PersonQueries(PersonBatchDataLoader dataLoader)
{
    public async Task<PersonGraphModel?> GetById(int personId)
    {
        var person = await dataLoader.LoadAsync(personId);
        return new PersonGraphModel(person);
    }

    public async Task<List<PersonGraphModel>> GetPeopleByIds(IReadOnlyCollection<int> personIds)
    {
        var people = await dataLoader.LoadAsync(personIds);
        return people.Select(x => new PersonGraphModel(x)).ToList();
    }

    public async Task<List<PersonGraphModel>> GetPeople([Service] PersonService personService)
    {
        return (await personService.GetPeople()).Select(x => new PersonGraphModel(x)).ToList();
    }

    public class PersonQueriesType : ObjectType<PersonQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonQueries> descriptor)
        {
            descriptor
                .Name("PersonQueries")
                .Description("People domain queries.");
        }
    }
}