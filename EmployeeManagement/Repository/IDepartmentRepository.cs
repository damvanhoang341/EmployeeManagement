using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> getAllDepartment();
        public List<Department> getDepartmentsByLocationId(string locationId);
        public IQueryable<Department> searchById(int id);
        public List<Department> searhDepartmentByName(string name, string locationID);
    }
}
