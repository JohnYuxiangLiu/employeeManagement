using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
        //public Employee Employee { get; set; } = new Employee();
        public Employee Employee { get; set; }

        //inject dependcy to use getEmployee()
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        //create id propterty param from request /employeedetails/id
        //linked to EmployeeDetails @page id
        [Parameter]
        public string Id { get; set; }

        //coordinates property
        protected string Coordinates { get; set; }


        //asign http to employee by init razor component once ready
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        //protected only in inherited sub class
        //func to display x y on name title
        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X={e.ClientX}, Y={e.ClientY}"; 
        }
    }
}
