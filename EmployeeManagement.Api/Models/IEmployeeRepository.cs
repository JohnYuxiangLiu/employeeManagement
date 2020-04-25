using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    //this reposotory will be implemented by others to execute the crud methods below
    public interface IEmployeeRepository
    {
        //Task: Represents an asynchronous operation.
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        //search employee name, and gender is optional
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    }
}
