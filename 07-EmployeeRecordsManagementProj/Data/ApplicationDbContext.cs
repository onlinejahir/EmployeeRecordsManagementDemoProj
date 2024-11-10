using _07_EmployeeRecordsManagementProj.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace _07_EmployeeRecordsManagementProj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //DebSet properties
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
