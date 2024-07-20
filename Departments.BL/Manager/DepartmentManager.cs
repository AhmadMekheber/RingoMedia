using Departments.BL.IManager;
using Departments.DAL.IRepository;
using Departments.Model;
using Departments.ViewModel;

namespace Departments.BL.Manager
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentViewModel?> GetDepartmentAsync(long departmentID)
        {
            DepartmentViewModel? departmentViewModel = null;

            Department? department = await _departmentRepository.GetDepartmentAsync(departmentID);

            if (department != null) {
                departmentViewModel = await MapToViewModel(department);
            }

            return departmentViewModel;
        }

        private async Task<DepartmentViewModel> MapToViewModel(Department department)
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel
            {
                ID = department.ID,
                Name = department.Name,
                LogoPath = department.LogoPath,
                ParentDepartmentID = department.ParentDepartmentID,
                SubDepartments = new List<DepartmentViewModel>()
            };

            var subDepartments = await _departmentRepository.GetSubDepartmentsAsync(department.ID);

            foreach (Department subDepartment in subDepartments)
            {
                departmentViewModel.SubDepartments.Add(await MapToViewModel(subDepartment));
            }

            return departmentViewModel;
        }
    }
}