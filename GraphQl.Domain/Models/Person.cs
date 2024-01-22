namespace GraphQl.Domain.Models;

public class Person(int id, string firstName, string lastName, int? motherId, int? fatherId, int? carId)
{
    public int Id { get; } = id;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public int? MotherId { get; } = motherId;
    public int? FatherId { get; } = fatherId;
    public int? CarId { get; } = carId;

    public Person? Mother { get; }
    public Person? Father { get; }
    public List<Person> Children { get; } = new();

    public Car? Car { get; }
}