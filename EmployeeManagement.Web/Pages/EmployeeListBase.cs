using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Web.Services;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowTooter { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            // await Task.Run(LoadEmployee);
            Employees =(await employeeService.GetEmployees()).ToList();
        }
    }
}
