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
        public Employee Employee { get; set; } = new Employee();

        //must have inject to do the inverse of control
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        //select dept to update
        public List<Department> Departments { get; set; } = new List<Department>();

        //with parameter, it gets it from url req
        //this Id has to be string because url req add is string
        [Parameter]
        public string Id { get; set; }

        //bind-value can't take int must be string, so create property here
        public string DepartmentId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));

            Departments = (await DepartmentService.GetDepartments()).ToList();

            DepartmentId = Employee.DepartmentId.ToString();
        }

    }
}
