using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDepartmentService
    {
        public List<Department> getAllDepartment();
        public List<Department> getDepartmentsByLocationId(string locationId);
        public List<Department> searhDepartmentByName(string name, string locationID);
        public IQueryable<Department> searchById(int id);
    }
}
