using System.ComponentModel.DataAnnotations;

namespace Departments.Model
{
    public class Reminder
    {
        [Key]
        public Guid ID { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public required DateTime RemindingDate { get; set; }
    }
}