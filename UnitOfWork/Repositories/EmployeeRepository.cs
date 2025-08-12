using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;
using UnitOfWork.Repositories.GenericRepo;

namespace UnitOfWork.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Employee>> GetEmployeesWithDepartmentAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }
    }
}
