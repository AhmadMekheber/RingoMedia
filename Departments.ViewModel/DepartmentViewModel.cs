namespace Departments.ViewModel
{
    public class DepartmentViewModel
    {
        public long ID { get; set; }
        public required string Name { get; set; }
        public required string LogoPath { get; set; }
        public long? ParentDepartmentID { get; set; }
        public List<DepartmentViewModel>? SubDepartments { get; set; }
    }
}