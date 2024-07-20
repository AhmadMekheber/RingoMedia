using Departments.DAL.BaseRepository;
using Departments.DAL.IRepository;
using Departments.Migrations.Data;
using Departments.Model;

namespace Departments.DAL.Reporsitory
{
    public class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext context) : base(context)
        {
        }
    }
}