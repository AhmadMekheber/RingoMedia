using Departments.BL.IManager;
using Departments.DAL.IRepository;
using Departments.Model;
using Departments.ViewModel;

namespace Departments.BL.Manager
{
    public class ReminderManager : IReminderManager
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderManager(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task CreateReminderAsync(CreateReminderViewModel viewModel) 
        {
            Reminder reminder = MapCreateReminderViewModelToModel(viewModel);
            _reminderRepository.Add(reminder);

            await _reminderRepository.SaveChangesAsync();
        }

        private Reminder MapCreateReminderViewModelToModel(CreateReminderViewModel viewModel)
        {
            return new Reminder
            {
                ID = Guid.NewGuid(),
                Title = viewModel.Title,
                Content = viewModel.Content,
                RemindingDate = viewModel.RemindingDate,
                IsMailSent = false
            };
        }

        public List<ReminderViewModel> GetAllReminders()
        {
            return _reminderRepository.GetAll()
                .Select(MapReminderToViewModel)
                .ToList();                
        }

        private ReminderViewModel MapReminderToViewModel(Reminder reminder)
        {
            return new ReminderViewModel
            {
                ID = reminder.ID,
                Title = reminder.Title,
                Content = reminder.Content,
                RemindingDate = reminder.RemindingDate,
                IsMailSent = reminder.IsMailSent
            };
        }
    }
}