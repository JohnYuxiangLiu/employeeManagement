using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase:ComponentBase
    {
        //must have inject otherwise will have nullexception
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } 
        
        //with parameter, it gets it from url req
        //this Id has to be string because url req add is string
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

    }
}
