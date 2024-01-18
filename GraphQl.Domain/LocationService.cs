using System.Collections.Generic;
using System.Linq;

namespace GraphQl.Domain
{
    public class LocationService
    {
        public List<Location> GetLocations() => Locations.LocationCollection;
        public Location? GetById(int id) => Locations.LocationCollection.FirstOrDefault(x => x.Id == id);
    }
}
