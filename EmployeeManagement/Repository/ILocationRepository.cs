using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ILocationRepository
    {
        public List<Location> GetLocations();
        public string? SearchId(string city);
    }
}
