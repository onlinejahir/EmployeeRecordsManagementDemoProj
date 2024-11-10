using _07_EmployeeRecordsManagementProj.DAL.Contracts;
using _07_EmployeeRecordsManagementProj.Data;
using _07_EmployeeRecordsManagementProj.EntityModels;

namespace _07_EmployeeRecordsManagementProj.DAL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
