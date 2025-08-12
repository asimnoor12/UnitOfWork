using UnitOfWork.Repositories;

namespace UnitOfWork.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        Task<int> CompleteAsync();
    }
}
