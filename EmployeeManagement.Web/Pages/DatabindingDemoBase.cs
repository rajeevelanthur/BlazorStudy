using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DatabindingDemoBase : ComponentBase
    {
        protected string Name { set; get; } = "Rajeev";
        protected string Gender { set; get; } = "Male";

        protected string Color { get; set; } = "background-color:white";
    }
}
