using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Data
{
    public class AppDbContext: DbContext
    {
        //Using Dependency injetion we will initialise DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                
        }
        public DbSet<Employee> Employees { get; set; }  
    }
}
