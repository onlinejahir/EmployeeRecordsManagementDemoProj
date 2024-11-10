using _07_EmployeeRecordsManagementProj.DAL.Contracts;
using _07_EmployeeRecordsManagementProj.Data;
using _07_EmployeeRecordsManagementProj.EntityModels;

namespace _07_EmployeeRecordsManagementProj.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
