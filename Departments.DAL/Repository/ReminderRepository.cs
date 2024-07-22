using Departments.DAL.BaseRepository;
using Departments.DAL.IRepository;
using Departments.Migrations.Data;
using Departments.Model;
using Microsoft.EntityFrameworkCore;

namespace Departments.DAL.Reporsitory
{
    public class ReminderRepository : EFRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Reminder>> GetRemindersToSend()
        {
            return await this.GetAll()
                .Where(reminder => reminder.IsMailSent == false && reminder.RemindingDate <= DateTime.Now)
                .ToListAsync();
        }

        public async Task MarkReminderAsSent(Reminder reminder) 
        {
            reminder.IsMailSent = true;

            await SaveChangesAsync();
        }
    }
}