using Departments.DAL.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Service.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}