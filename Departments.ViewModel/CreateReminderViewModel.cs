namespace Departments.ViewModel
{
    public class CreateReminderViewModel
    {
        public required string Title { get; set; }

        public required string Content { get; set; }

        public required DateTime RemindingDate { get; set; }
    }
}