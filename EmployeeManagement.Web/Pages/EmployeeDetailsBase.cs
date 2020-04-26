using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//provides data to employeeDetails.rasor page
namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        //to display employee
        public Employee Employee { get; set; } = new Employee();

        //inject dependcy to use getEmployee()
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        //create id propterty param from request /employeedetails/id
        //linked to EmployeeDetails @page id
        [Parameter]
        public string Id { get; set; }


        //asign http to employee by init razor component once ready
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
    }
}
