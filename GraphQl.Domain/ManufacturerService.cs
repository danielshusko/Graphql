using GraphQl.Domain.Models;

namespace GraphQl.Domain;

public class ManufacturerService
{
    public async Task<List<Manufacturer>> GetByIds(IReadOnlyCollection<int> ids)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting manufacturers: {string.Join(",", ids)}");
        return (await Data.Data.Manufacturers).Where(x => ids.Contains(x.Id)).ToList();
    }
}