using GraphQl.Domain;
using GraphQl.GraphQl.Domain.DataLoaders;
using GraphQl.GraphQl.Domain.Models;
using HotChocolate.Data.Filters;
using HotChocolate.Types.Pagination;


// ReSharper disable VirtualMemberCallInConstructor

namespace GraphQl.GraphQl.Domain;

[GraphQLDescription("Queries for people.")]
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

    [UsePaging(IncludeTotalCount = true)]
    public async Task<Connection<PersonGraphModel>> GetPeople([Service] PersonService personService, string? after, int? first, string sortBy)
    {
        PersonService.PersonSortField? personSortField = null;
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            if (Enum.TryParse<PersonService.PersonSortField>(sortBy, true, out var parsedValue))
            {
                personSortField = parsedValue;
            }
            else
            {
                throw new ArgumentException($"Cannot sort by {sortBy}");
            }
        }

        int? skip = string.IsNullOrWhiteSpace(after)
            ? null
            : int.TryParse(after, out var value)
                ? value
                : null;

        var people = await personService.GetPeople(skip, first, personSortField);
        var peopleCount = (await personService.GetPeople()).Count;

        var peopleGraphModels = people.Select(x => new PersonGraphModel(x));
        var edges = peopleGraphModels.Select(x => new Edge<PersonGraphModel>(x, x.Id.ToString())).ToList();

        var firstPageIndex = skip ?? 0;
        var lastPageIndex = firstPageIndex + people.Count-1;
        var pageInfo = new ConnectionPageInfo(lastPageIndex<peopleCount-1, firstPageIndex>0, firstPageIndex.ToString(), lastPageIndex.ToString());
        
        var connection = new Connection<PersonGraphModel>(edges, pageInfo, ct => ValueTask.FromResult(peopleCount));

        return connection;
    }
}

public class PersonFilterType : FilterInputType<PersonGraphModel>
{
    protected override void Configure(
        IFilterInputTypeDescriptor<PersonGraphModel> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        //descriptor.Field(f => f.Name).Name("custom_name");
    }
}

