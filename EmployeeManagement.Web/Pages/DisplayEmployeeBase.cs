using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {
        //parameter means the sub class takes 2 params
        [Parameter]
        public Employee Employee { get; set; }

        //this ShowFooter get data from EmployeeListBase ShowFooter, and then pass to DisplayEmployee.razer
        //child must have params maching parents
        [Parameter]
        public bool ShowFooter { get; set; }
        /////////////////////////////////
        
        //passing child checkbox true or false to parent count
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        protected bool IsSelected { get; set; }

        //passing child to parent callback
        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnEmployeeSelection.InvokeAsync(IsSelected);
        }
        //////////////////////////////////////////
        


    }
}
