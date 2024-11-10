namespace _07_EmployeeRecordsManagementProj.BLL.Contracts
{
    public interface IUnitManager : IDisposable, IAsyncDisposable
    {
        Task<bool> SaveChangesAsync();
    }
}
