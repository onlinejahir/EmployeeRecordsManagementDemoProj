namespace _07_EmployeeRecordsManagementProj.DAL.Contracts
{
    public interface GenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<T?> GetByIdAsync(int? id);
        Task<IQueryable<T>> GetAllAsync();
    }
}
