using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Departments.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Departments",
                columns: ["Name", "LogoPath", "ParentDepartmentID"],
                values: new object[,] {
                    {"Ringo HQ - US", "https://ringomedia.com/assets/img/logo-light.svg", null},
                    {"Ringo HQ - EG", "https://ringomedia.com/assets/img/logo-light.svg", null},
                    {"US Sub 1", "https://ringomedia.com/assets/img/logo-light.svg", 1},
                    {"US Sub 2", "https://ringomedia.com/assets/img/logo-light.svg", 1},
                    {"US Sub 1-1", "https://ringomedia.com/assets/img/logo-light.svg", 3},
                    {"EG Sub 1", "https://ringomedia.com/assets/img/logo-light.svg", 2}
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
