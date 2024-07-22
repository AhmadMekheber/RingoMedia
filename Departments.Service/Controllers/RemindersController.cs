using Departments.BL.IManager;
using Departments.Model;
using Departments.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IReminderManager _reminderManager;

        public ReminderController(IReminderManager reminderManager)
        {
            _reminderManager = reminderManager;
        }

        // GET: Reminders
        public IActionResult Index()
        {
            return View(_reminderManager.GetAllReminders());
        }

        // GET: Reminders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reminders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,RemindingDate")] CreateReminderViewModel reminder)
        {
            if (ModelState.IsValid)
            {
                await _reminderManager.CreateReminderAsync(reminder);
                
                return RedirectToAction(nameof(Index));
            }
            return View(reminder);
        }
    }
}