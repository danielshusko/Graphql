using GraphQl.Domain;
using GraphQl.Domain.Models;

namespace GraphQl.GraphQl.Domain.DataLoaders;

public class PersonGroupDataLoader(
        PersonService personService,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
    : GroupedDataLoader<int, List<Person>>(batchScheduler, options)
{
    protected override async Task<ILookup<int, List<Person>>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var children = await personService.GetByParentIds(keys);

        var fatherGroupings = children.GroupBy(x => x.FatherId!.Value);
        var motherGroupings = children.GroupBy(x => x.MotherId!.Value);
        var parentGroupings = motherGroupings
            .Union(fatherGroupings);

        return parentGroupings.ToLookup(x => x.Key, x => x.ToList());
    }
}