using Departments.DAL.BaseRepository;
using Departments.Model;

namespace Departments.DAL.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department?> GetDepartmentAsync(long departmentID);        
        
        Task<List<Department>> GetDepartments();

        Task<List<Department>> GetSubDepartmentsAsync(long parentDepartmentID);
    }
}