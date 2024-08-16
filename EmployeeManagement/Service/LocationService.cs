using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationService = new LocationRepository();
        public List<Location> GetLocations()
        {
            return _locationService.GetLocations();
        }
        public string? SearchId(string city)
        {
            return _locationService.SearchId(city);
        }
    }
}
