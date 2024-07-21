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

        public async Task<List<DepartmentViewModel>> GetDepartmentsAsync() {
            var departments = await _departmentRepository.GetDepartments();

            return departments
                .Select(MapDepartment)
                .ToList();
        }

        public async Task<DepartmentViewModel?> GetDepartmentAsync(long departmentID)
        {
            DepartmentViewModel? departmentViewModel = null;

            Department? department = await _departmentRepository.GetDepartmentAsync(departmentID);

            if (department != null) {
                departmentViewModel = await MapWithSubDepartments(department);
            }

            return departmentViewModel;
        }

        private DepartmentViewModel MapDepartment(Department department) 
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel
            {
                ID = department.ID,
                Name = department.Name,
                LogoPath = department.LogoPath,
                ParentDepartmentID = department.ParentDepartmentID,
            };

            return departmentViewModel;
        }

        private async Task<DepartmentViewModel> MapWithSubDepartments(Department department)
        {
            DepartmentViewModel departmentViewModel = MapDepartment(department);

            await MapSubDepartments(department, departmentViewModel);

            return departmentViewModel;
        }

        private async Task MapSubDepartments(Department department, DepartmentViewModel departmentViewModel) 
        {
            departmentViewModel.SubDepartments = new List<DepartmentViewModel>();

            var subDepartments = await _departmentRepository.GetSubDepartmentsAsync(department.ID);

            foreach (Department subDepartment in subDepartments)
            {
                departmentViewModel.SubDepartments?.Add(await MapWithSubDepartments(subDepartment));
            }
        }
    
        public async Task<List<DepartmentViewModel>> GetDepartmentHierarchy(long departmentID)
        {
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();

            Department? department = await _departmentRepository.GetDepartmentAsync(departmentID);

            if (department == null)
            {
                return departmentViewModels;
            }

            departmentViewModels.Add(MapDepartment(department));

            while (department.ParentDepartmentID != null)
            {
                department = await _departmentRepository.GetDepartmentAsync(department.ParentDepartmentID.Value);

                if (department != null)
                {
                    departmentViewModels.Add(MapDepartment(department));
                }
                else 
                {
                    break;
                }
            }

            return departmentViewModels;
        }
    }
}