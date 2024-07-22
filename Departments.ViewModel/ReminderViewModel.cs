namespace Departments.ViewModel
{
    public class ReminderViewModel
    {
        public Guid ID { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public required DateTime RemindingDate { get; set; }

        public bool IsMailSent { get; set; }
    }
}