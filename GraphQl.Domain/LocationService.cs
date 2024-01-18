namespace GraphQl.Domain;

public class LocationService
{
    public List<Location> GetLocations()
    {
        return Locations.LocationCollection;
    }

    public Location? GetById(int id)
    {
        return Locations.LocationCollection.FirstOrDefault(x => x.Id == id);
    }
}