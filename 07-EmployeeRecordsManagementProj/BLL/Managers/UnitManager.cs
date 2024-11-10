using _07_EmployeeRecordsManagementProj.BLL.Contracts;
using _07_EmployeeRecordsManagementProj.DAL.Contracts;

namespace _07_EmployeeRecordsManagementProj.BLL.Managers
{
    public class UnitManager : IUnitManager
    {
        private readonly IUnitRepository _unitRepository;
        public UnitManager(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _unitRepository.SaveChangesAsync();
        }
        public void Dispose()
        {
            _unitRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_unitRepository is IAsyncDisposable asyncDisposableRepo)
            {
                await asyncDisposableRepo.DisposeAsync();  // Dispose asynchronously
            }
            else
            {
                _unitRepository.Dispose();  // Fallback to synchronous disposal
            }

            GC.SuppressFinalize(this);
        }
    }
}
