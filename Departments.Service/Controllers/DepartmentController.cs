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

        public async Task<IActionResult> Index(long departmentID)
        {
            var department = await _departmentManager.GetDepartmentAsync(departmentID);

            return View(department);
        }
    }
}