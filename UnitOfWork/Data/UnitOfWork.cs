using UnitOfWork.Repositories;

namespace UnitOfWork.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }

        public UnitOfWork(AppDbContext context, IEmployeeRepository employeeRepo, IDepartmentRepository departmentRepo)
        {
            _context = context;
            Employees = employeeRepo;
            Departments = departmentRepo;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}
