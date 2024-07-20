using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RingoMedia.Model
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(200)]
        public required string LogoPath { get; set; }

        public long? ParentDepartmentID { get; set; }

        //
        //Navigation Properties
        //
        [ForeignKey(nameof(ParentDepartmentID))]
        public virtual Department? ParentDepartment { get; set; }

        public virtual ICollection<Department>? SubDepartments { get; set; }
    }
}