using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        //need to create a constructor passing AppDbContext
        public EmployeeRepository (AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        //task: Represents an asynchronous operation.
        public async Task<Employee> AddEmployee(Employee employee)
        {
            //add to AppDbContext first
            var result = await appDbContext.Employees.AddAsync(employee);
            //save newly added employee to db
            await appDbContext.SaveChangesAsync();
            //return all employee in entity type for the db, because entity type is to save to db
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            //if result==null
            return null;

        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            //include: doesn't need to specify type because dept inc in employee, and Task<Employee>
            return await appDbContext.Employees
                .Include(e=>e.Department)
                .FirstOrDefaultAsync(e=>e.EmployeeId==employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //async create a list of Employee type 
            return await appDbContext.Employees.ToListAsync();
        }

        //search employee name and gender which is optional
        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            //provide func to query employees through appdbcontext
            IQueryable<Employee> query = appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                //query=: needs to asign to query to return
                query=query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query=query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();

        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            //find by employee id first
            //compare user input with db data
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.EmployeeId = employee.EmployeeId;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }



    }
}
