namespace GraphQl.Domain;

public static class Locations
{
    public static Location WhiteHouse = new(1, "WH", "White House", new Address("1600 Pennsylvania Avenue NW", "Washington", States.DC, "20500"));
    public static Location EmpireStateBuilding = new(2, "ESB", "Empire State Building", new Address("20 W 34th St", "New York", States.NY, "10001"));
    public static Location ChryslerBuilding = new(3, "CB", "Chrysler Building", new Address("405 Lexington Ave", "New York", States.NY, "10174"));
    public static Location RockefellerCenter = new(4, "RC", "Rockefeller Center", new Address("45 Rockefeller Plaza", "New York", States.NY, "10111"));
    public static Location SpaceNeedle = new(5, "SN", "Space Needle", new Address("400 Broad St", "Seattle", States.WA, "98109"));

    public static List<Location> LocationCollection => new()
    {
        WhiteHouse, EmpireStateBuilding, ChryslerBuilding, RockefellerCenter, SpaceNeedle
    };
}