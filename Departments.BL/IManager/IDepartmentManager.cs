using Departments.ViewModel;

namespace Departments.BL.IManager
{
    public interface IDepartmentManager
    {
        Task<DepartmentViewModel?> GetDepartmentAsync(long departmentID);
    }
}