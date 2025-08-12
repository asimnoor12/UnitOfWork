using UnitOfWork.Models;
using UnitOfWork.Repositories.GenericRepo;

namespace UnitOfWork.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesWithDepartmentAsync();
    }
}
