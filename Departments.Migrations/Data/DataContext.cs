using Microsoft.EntityFrameworkCore;
using Departments.Model;

namespace Departments.Migrations.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
            .HasOne(department => department.ParentDepartment)
            .WithMany(parentDepartment => parentDepartment.SubDepartments)
            .HasForeignKey(department => department.ParentDepartmentID);
        }

        public DbSet<Department> Departments { get; set; }
    }
}