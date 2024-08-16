using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly EmployeeManagementContext _context = new EmployeeManagementContext();
        public List<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public string? SearchId(string city)
        {
            var locationSearch =  _context.Locations.FirstOrDefault(l=>l.City!=null && l.City.Equals(city));
            return (locationSearch?.LocationId);
        }
    }
}
