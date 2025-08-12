using UnitOfWork.Data;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context) { }
    }
}
