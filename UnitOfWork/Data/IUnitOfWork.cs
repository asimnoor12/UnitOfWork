using UnitOfWork.Repositories;

namespace UnitOfWork.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        Task<int> CompleteAsync();
    }
}
