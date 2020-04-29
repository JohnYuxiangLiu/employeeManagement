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

        //button hide footer property
        //assign ButtonText default value to Hide Text
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; }
        //////////////////////////////////////////////




        //asign http to employee by init razor component once ready
        protected async override Task OnInitializedAsync()
        {
            //default to employee 1 details
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        //protected only in inherited sub class
        //func to display x y on name title
        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X={e.ClientX}, Y={e.ClientY}"; 
        }

        //click button to hide footer
        protected void Button_Click()
        {
            if(ButtonText=="Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }





    }
}
