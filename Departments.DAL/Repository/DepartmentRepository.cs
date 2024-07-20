using Departments.DAL.BaseRepository;
using Departments.DAL.IRepository;
using Departments.Migrations.Data;
using Departments.Model;
using Microsoft.EntityFrameworkCore;

namespace Departments.DAL.Reporsitory
{
    public class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext context) : base(context)
        {
        }

        public async Task<Department?> GetDepartmentAsync(long departmentID)
        {
            return await this.GetAll()
                .Where(department => department.ID == departmentID)
                .FirstOrDefaultAsync();
        }

        public IQueryable<Department> GetDepartments()
        {
            return this.GetAll()
                .Where(department => department.ParentDepartmentID == null);
        }

        public async Task<List<Department>> GetSubDepartmentsAsync(long parentDepartmentID)
        {
            return await this.GetAll()
                .Where(subDepartment => subDepartment.ParentDepartmentID == parentDepartmentID)
                .ToListAsync();
        }
    }
}