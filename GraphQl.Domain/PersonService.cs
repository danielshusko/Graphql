using GraphQl.Domain.Models;

namespace GraphQl.Domain;

public class PersonService
{
    public enum PersonSortField
    {
        Id,
        FirstName,
        LastName
    }

    public async Task<List<Person>> GetPeople(int? skip = null, int? take = null, PersonSortField? sortBy = null)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")}: Getting all people");
        var peopleQuery = (await Data.Data.People).AsEnumerable();

        if (sortBy != null)
            switch (sortBy)
            {
                case PersonSortField.FirstName:
                    peopleQuery = peopleQuery.OrderBy(x => x.FirstName);
                    break;
                case PersonSortField.LastName:
                    peopleQuery = peopleQuery.OrderBy(x => x.LastName);
                    break;
                default:
                    peopleQuery = peopleQuery.OrderBy(x => x.Id);
                    break;
            }

        if (skip.HasValue) peopleQuery = peopleQuery.Skip(skip.Value);

        if (take.HasValue) peopleQuery = peopleQuery.Take(take.Value);

        return peopleQuery.ToList();
    }

    public async Task<IQueryable<Person>> GetPeopleQueryable()
    {
        return (await Data.Data.People).AsQueryable();
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