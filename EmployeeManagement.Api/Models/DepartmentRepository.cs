using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Department GetDepartmentId(int departmentId)
        {
            return appDbContext.Departments.FirstOrDefault(e => e.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            //or tolist is to create a list of Department type
            return appDbContext.Departments;
        }
    }
}
