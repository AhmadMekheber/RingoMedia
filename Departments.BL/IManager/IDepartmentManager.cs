using Departments.ViewModel;

namespace Departments.BL.IManager
{
    public interface IDepartmentManager
    {
        Task<List<DepartmentViewModel>> GetDepartmentsAsync();

        Task<DepartmentViewModel?> GetDepartmentAsync(long departmentID);
    }
}