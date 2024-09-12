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

        public async Task updateEmployee(int id, Employee emp)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            employee.Mobile = emp.Mobile;
            employee.Age = emp.Age;
            employee.Salary = emp.Salary;
            employee.Status = emp.Status;

            await db.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

        }
    }
}
