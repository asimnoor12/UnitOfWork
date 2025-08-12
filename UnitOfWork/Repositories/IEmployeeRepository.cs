using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesWithDepartmentAsync();
    }
}
