using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = new DepartmentRepository();
        public List<Department> getAllDepartment()
        {
            return _departmentRepository.getAllDepartment();
        }
        public List<Department> getDepartmentsByLocationId(string locationId)
        {
            return _departmentRepository.getDepartmentsByLocationId(locationId);
        }
        public List<Department> searhDepartmentByName(string name, string locationID)
        {
            return _departmentRepository.searhDepartmentByName(name, locationID);
        }
        public IQueryable<Department> searchById(int id)
        {
            return _departmentRepository.searchById(id);
        }
    }
}
