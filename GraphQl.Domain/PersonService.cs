using GraphQl.Domain.Models;

namespace GraphQl.Domain;

public class PersonService
{
    public async Task<List<Person>> GetPeople()
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting all people");
        return await Data.Data.People;
    }
    public async Task<List<Person>> GetByIds(IReadOnlyCollection<int> ids)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting people: {string.Join(",", ids)}");
        return (await Data.Data.People).Where(x => ids.Contains(x.Id)).ToList();
    }
    public async Task<List<Person>> GetByParentIds(IReadOnlyCollection<int> ids)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting people by parent ids: {string.Join(",", ids)}");
        return (await Data.Data.People).Where(x => (x.FatherId.HasValue && ids.Contains(x.FatherId.Value)) || (x.MotherId.HasValue && ids.Contains(x.MotherId.Value))).ToList();
    }

    public async Task<Person?> GetById(int id)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting person: {id}");
        return (await Data.Data.People).FirstOrDefault(x => x.Id == id);
    }
}

public class CarService
{
    public async Task<List<Car>> GetByIds(IReadOnlyCollection<int> ids)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting cars: {string.Join(",", ids)}");
        return (await Data.Data.Cars).Where(x => ids.Contains(x.Id)).ToList();
    }
}
public class ManufacturerService
{
    public async Task<List<Manufacturer>> GetByIds(IReadOnlyCollection<int> ids)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting manufacturers: {string.Join(",", ids)}");
        return (await Data.Data.Manufacturers).Where(x => ids.Contains(x.Id)).ToList();
    }
}