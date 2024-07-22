using Departments.DAL.BaseRepository;
using Departments.DAL.IRepository;
using Departments.Migrations.Data;
using Departments.Model;

namespace Departments.DAL.Reporsitory
{
    public class ReminderRepository : EFRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(DataContext context) : base(context)
        {
        }
    }
}