using GraphQl.Domain.Models;

namespace GraphQl.Domain;

public class CarService
{
    public async Task<List<Car>> GetByIds(IReadOnlyCollection<int> ids)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting cars: {string.Join(",", ids)}");
        return (await Data.Data.Cars).Where(x => ids.Contains(x.Id)).ToList();
    }
}