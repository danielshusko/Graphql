using GraphQl.Domain;
using GraphQl.Domain.Models;

namespace GraphQl.GraphQl.Domain.DataLoaders;

public class PersonBatchDataLoader(
        PersonService personService,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
    : BatchDataLoader<int, Person>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Person>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var people = (await personService.GetByIds(keys)).ToDictionary(x => x.Id, x => x);
        return people;
    }
}