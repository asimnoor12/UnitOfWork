using UnitOfWork.Data;
using UnitOfWork.Models;
using UnitOfWork.Repositories.GenericRepo;

namespace UnitOfWork.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context) { }
    }
}
