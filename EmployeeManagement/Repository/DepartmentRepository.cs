using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeManagementContext _context = new EmployeeManagementContext();
        public List<Department> getAllDepartment()
        {
            return _context.Departments
                           .Include(d => d.Location)
                           .Include(d => d.Manager)
                           .ToList();
        }

        public List<Department> getDepartmentsByLocationId(string locationId)
        {
             return _context.Departments.Where(d => d.LocationId.Equals(locationId))
                            .Include(d=> d.Location)
                            .Include(d=> d.Manager)
                            .ToList();
        }

        public List<Department> searhDepartmentByName(string name, string locationID)
        {
            if (!string.IsNullOrEmpty(locationID) && !locationID.Equals("Select All"))
            {
                return  _context.Departments.Where(d => d.LocationId.Equals(locationID) && d.DepartmentName.Contains(name)).Include(d => d.Location)
                            .Include(d => d.Manager).ToList(); 
            }
            return _context.Departments.Where(d=>d.DepartmentName.Contains(name)).Include(d => d.Location)
                            .Include(d => d.Manager).ToList(); 
        }

        public IQueryable<Department> searchById(int id)
        {
            var departmentQuery = _context.Departments.Where(d => d.DepartmentId == id);
            return departmentQuery;
        }

    }
}
