using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;

namespace EmployeeManagement.Web.Pages
{
    //employees data page
    public class EmployeeListBase : ComponentBase
    {
        //use inject instead of constructor to inject EmployeeService, because EmployeeListBase is a blazor component
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        //create a connection of employee class
        public IEnumerable<Employee> Employees { get; set; }



        //load all employees list LoadEmployees to initaliser
        protected override async Task OnInitializedAsync()
        {
            //LoadEmployees(); //exec to load all employees, use without db
 
            //asign getEmployees result to employees for razor to use
            Employees= (await EmployeeService.GetEmployees()).ToList();
        }

        ////manually load all employees to db, use without db
        //private void LoadEmployees()
        //{
        //    Employee e1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "John",
        //        LastName = "Hastings",
        //        Email = "David@pragimtech.com",
        //        DateOfBirth = new DateTime(1980, 10, 5),
        //        Gender = Gender.Male,
        //        DepartmentId = 1,
        //        PhotoPath = "images/john.png"
        //    };

        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 2,
        //        FirstName = "Sam",
        //        LastName = "Galloway",
        //        Email = "Sam@pragimtech.com",
        //        DateOfBirth = new DateTime(1981, 12, 22),
        //        Gender = Gender.Male,
        //        DepartmentId = 2,
        //        PhotoPath = "images/sam.jpg"
        //    };

        //    Employee e3 = new Employee
        //    {
        //        EmployeeId = 3,
        //        FirstName = "Mary",
        //        LastName = "Smith",
        //        Email = "mary@pragimtech.com",
        //        DateOfBirth = new DateTime(1979, 11, 11),
        //        Gender = Gender.Female,
        //        DepartmentId = 3,
        //        PhotoPath = "images/mary.png"
        //    };

        //    Employee e4 = new Employee
        //    {
        //        EmployeeId = 4,
        //        FirstName = "Sara",
        //        LastName = "Longway",
        //        Email = "sara@pragimtech.com",
        //        DateOfBirth = new DateTime(1982, 9, 23),
        //        Gender = Gender.Female,
        //        DepartmentId = 4,
        //        PhotoPath = "images/sara.png"
        //    };

        //    //assign the list of employees to Employees IEnumerable connection
        //    Employees = new List<Employee> { e1, e2, e3, e4 };

        //}
    }
}
