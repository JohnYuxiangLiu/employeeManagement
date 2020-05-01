using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Department> GetDepartment(int departmentId)
        {
            //FirstOrDefaultAsync to use awaitable
            return await appDbContext.Departments.FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            //or tolist is to create a list of Department type
            //tolistasync to use awaitable
            return await appDbContext.Departments.ToListAsync();
        }
    }
}
