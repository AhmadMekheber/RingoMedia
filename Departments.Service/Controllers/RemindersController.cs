using Departments.Model;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Controllers
{
    public class ReminderController : Controller
    {
        private static List<Reminder> reminders = new List<Reminder>();

        // GET: Reminders
        public IActionResult Index()
        {
            return View(reminders);
        }

        // GET: Reminders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reminders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Title,Content,RemindingDate")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                reminder.ID = Guid.NewGuid();
                reminders.Add(reminder);
                return RedirectToAction(nameof(Index));
            }
            return View(reminder);
        }
    }
}