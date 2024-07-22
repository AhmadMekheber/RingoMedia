using Departments.ViewModel;

namespace Departments.BL.IManager
{
    public interface IReminderManager
    {
        Task CreateReminderAsync(CreateReminderViewModel viewModel);

        List<ReminderViewModel> GetAllReminders();
    }
}