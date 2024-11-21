using _07_EmployeeRecordsManagementProj.DAL.Contracts;
using _07_EmployeeRecordsManagementProj.Data;
using _07_EmployeeRecordsManagementProj.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace _07_EmployeeRecordsManagementProj.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public override async Task<IQueryable<Employee>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Employees
                .Include(e => e.Department).AsQueryable());
        }
    }
}
