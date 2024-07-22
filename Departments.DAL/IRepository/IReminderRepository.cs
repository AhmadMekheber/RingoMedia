using Departments.DAL.BaseRepository;
using Departments.Model;

namespace Departments.DAL.IRepository
{
    public interface IReminderRepository : IRepository<Reminder>
    {
        Task<List<Reminder>> GetRemindersToSend();

        Task MarkReminderAsSent(Reminder reminder);
    }
}