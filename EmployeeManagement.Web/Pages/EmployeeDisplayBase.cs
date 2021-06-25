﻿using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDisplayBase : ComponentBase
    {
        [Parameter]
        public Employee  Employee { get; set; }
        [Parameter]
        public bool ShooFooter { get; set; } = true;
    }
}