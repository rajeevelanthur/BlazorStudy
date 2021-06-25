using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new Department() { DepartmentId = 1, DepartmentName = "Microsoft" });
            modelBuilder.Entity<Department>().HasData(new Department() { DepartmentId = 2, DepartmentName = "Java" });
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                EmployeeId = 1,
                FirstName = "Rajeev",
                LastName = "Kumar",
                Email = "rajeevkumar.rajan@speridian.com",
                DateOfBirth = new DateTime(1986, 05, 31),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Rajeev.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                EmployeeId = 2,
                FirstName = "Bijith",
                LastName = "Kumar",
                Email = "Bijithkumar.meethal@speridian.com",
                DateOfBirth = new DateTime(1980, 08, 9),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Bijith.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                EmployeeId = 3,
                FirstName = "Sibin",
                LastName = "Babu",
                Email = "sibin.babu@speridian.com",
                DateOfBirth = new DateTime(1984, 04, 23),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Sibin.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                EmployeeId = 4,
                FirstName = "Roshin",
                LastName = "Raj",
                Email = "roshin.raj@speridian.com",
                DateOfBirth = new DateTime(1985, 09, 15),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/Roshin.png"
            });

        }
      
    }
}
