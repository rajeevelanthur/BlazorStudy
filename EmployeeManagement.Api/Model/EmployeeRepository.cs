using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Model
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _appDbContext = null;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
           var result = await  _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result =  await _appDbContext.Employees.FirstOrDefaultAsync(k => k.EmployeeId == employeeId);
            if( result!=null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await _appDbContext.Employees
                .Include(e=>e.Department)
                .FirstOrDefaultAsync(k => k.EmployeeId == employeeId);
            return result;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var result = await _appDbContext.Employees
                 .Include(e => e.Department)
                .FirstOrDefaultAsync(k => k.Email == email);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if(gender!=null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await  query.ToListAsync();

        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(k => k.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null; 
        }
    }
}
