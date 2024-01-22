using GraphQl.Domain.Models;

// ReSharper disable InconsistentNaming

namespace GraphQl.Domain.Data;

public static class Data
{
    public static Manufacturer Manufacturer_Toyota => new(1, "Toyota", "Japan");
    public static Manufacturer Manufacturer_Honda => new(2, "Honda", "Japan");
    public static Manufacturer Manufacturer_Jaguar => new(3, "Jaguar", "UK");
    public static Manufacturer Manufacturer_Chevrolet => new(4, "Chevrolet", "US");
    public static Manufacturer Manufacturer_Ford => new(5, "Ford", "UD");

    public static Car Car_Prius => new(1, "Prius", Manufacturer_Toyota.Id);
    public static Car Car_Rav4 => new(2, "Rav4", Manufacturer_Toyota.Id);
    public static Car Car_Tundra => new(3, "Tundra", Manufacturer_Toyota.Id);
    public static Car Car_Pilot => new(4, "Pilot", Manufacturer_Honda.Id);
    public static Car Car_Civic => new(5, "Civic", Manufacturer_Honda.Id);
    public static Car Car_XF => new(6, "XF", Manufacturer_Jaguar.Id);
    public static Car Car_Corvette => new(7, "Corvette", Manufacturer_Chevrolet.Id);
    public static Car Car_Tahoe => new(8, "Tahoe", Manufacturer_Chevrolet.Id);
    public static Car Car_Bronco => new(9, "Bronco", Manufacturer_Ford.Id);
    public static Car Car_F150 => new(10, "F-150", Manufacturer_Ford.Id);

    public static Person Person_GF1 => new(1, "GF", "Family1", null, null, 1);
    public static Person Person_GM1 => new(2, "GM", "Family2", null, null, 2);
    public static Person Person_M1 => new(3, "M", "Family1", 2, 1, 3);
    public static Person Person_F1 => new(4, "F", "Family1", null, null, 4);
    public static Person Person_C1_1 => new(5, "C1", "Family1", 3, 4, null);
    public static Person Person_C1_2 => new(6, "C2", "Family1", 3, 4, null);
    public static Person Person_GF2 => new(7, "GrandFather", "Family2", null, null, 5);
    public static Person Person_GM2 => new(8, "GrandMother", "Family2", null, null, 6);
    public static Person Person_M2 => new(9, "Mother", "Family2", 8, 7, 7);
    public static Person Person_F2 => new(10, "Father", "Family2", null, null, 8);
    public static Person Person_C2_1 => new(11, "Child1", "Family2", 9, 10, null);
    public static Person Person_C2_2 => new(12, "Child2", "Family2", 9, 10, null);

    public static Task<List<Manufacturer>> Manufacturers => GetAllProperties<Manufacturer>();
    public static Task<List<Car>> Cars => GetAllProperties<Car>();
    public static Task<List<Person>> People => GetAllProperties<Person>();

    private static Task<List<T>> GetAllProperties<T>()
    {
        var properties = typeof(Data).GetProperties()
            .Where(x => x.PropertyType == typeof(T))
            .Select(x => x.GetValue(null))
            .Cast<T>()
            .ToList();

        return Task.FromResult(properties);
    }
}