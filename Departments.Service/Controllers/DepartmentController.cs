using Departments.BL.IManager;
using Departments.DAL.IRepository;
using Departments.Model;
using Departments.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Service.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentManager _departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentManager.GetDepartmentsAsync();

            return View(departments);
        }

        public async Task<IActionResult> DepartmentDetails(long departmentID)
        {
            var department = await _departmentManager.GetDepartmentAsync(departmentID);

            if (department == null)
            {
                return NotFound(departmentID);
            }

            return View(department);
        }

        public async Task<IActionResult> DepartmentHierarchy(long departmentID)
        {
            List<DepartmentViewModel> departmentViewModels = await _departmentManager.GetDepartmentHierarchy(departmentID);

            return View(departmentViewModels);
        }
    }
}