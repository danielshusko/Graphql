using GraphQl.Domain;
using GraphQl.Domain.Models;

namespace GraphQl.GraphQl.Domain.DataLoaders;

public class ManufacturerBatchDataLoader(
        ManufacturerService manufacturerService,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
    : BatchDataLoader<int, Manufacturer>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Manufacturer>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var manufacturers = await manufacturerService.GetByIds(keys);
        return manufacturers.ToDictionary(x => x.Id, x => x);
    }
}