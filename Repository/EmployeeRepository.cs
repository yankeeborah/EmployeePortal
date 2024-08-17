using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext dbContext)       //Constructor Dependency Injection
        {
            this.db = dbContext;
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await db.Employees.ToListAsync();
        }
        public async Task SaveEmployee(Employee emp)
        { 
            await db.Employees.AddAsync(emp);
            await db.SaveChangesAsync();
        }
    }


}
