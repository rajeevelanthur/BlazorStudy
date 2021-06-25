using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Model
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private AppDbContext _appDbContext = null;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public  Department GetDepartment(int departmentId)
        {
            return _appDbContext.Departments.FirstOrDefault(j => j.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.Departments;
        }
    }
}
