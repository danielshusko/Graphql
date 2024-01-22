using GraphQl.Domain.Models;
// ReSharper disable InconsistentNaming

namespace GraphQl.Data
{
    public static class Data
    {
        public static Manufacturer Manufacturer_Toyota = new(1, "Toyota", "Japan");
        public static Manufacturer Manufacturer_Honda = new(2, "Honda", "Japan");
        public static Manufacturer Manufacturer_Jaguar = new(3, "Jaguar", "UK");
        public static Manufacturer Manufacturer_Chevrolet = new(4, "Chevrolet", "US");
        public static Manufacturer Manufacturer_Ford = new(5, "Ford", "UD");

        public static Car Car_Prius = new(1, "Prius", Manufacturer_Toyota.Id);
        public static Car Car_Rav4 = new(2, "Rav4", Manufacturer_Toyota.Id);
        public static Car Car_Tundra = new(3, "Tundra", Manufacturer_Toyota.Id);
        public static Car Car_Pilot = new(4, "Pilot", Manufacturer_Honda.Id);
        public static Car Car_Civic = new(5, "Civic", Manufacturer_Honda.Id);
        public static Car Car_XF = new(6, "XF", Manufacturer_Jaguar.Id);
        public static Car Car_Corvette = new(7, "Corvette", Manufacturer_Chevrolet.Id);
        public static Car Car_Tahoe = new(8, "Tahoe", Manufacturer_Chevrolet.Id);
        public static Car Car_Bronco = new(9, "Bronco", Manufacturer_Ford.Id);
        public static Car Car_F150 = new(10, "F-150", Manufacturer_Ford.Id);
    }
}
