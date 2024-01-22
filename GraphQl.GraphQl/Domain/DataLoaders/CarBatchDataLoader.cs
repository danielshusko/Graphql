using GraphQl.Domain;
using GraphQl.Domain.Models;

namespace GraphQl.GraphQl.Domain.DataLoaders;

public class CarBatchDataLoader(
        CarService carService,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
    : BatchDataLoader<int, Car>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Car>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var cars = await carService.GetByIds(keys);
        return cars.ToDictionary(x => x.Id, x => x);
    }
}