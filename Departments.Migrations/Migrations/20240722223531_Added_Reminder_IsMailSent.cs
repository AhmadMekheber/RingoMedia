using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Departments.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Added_Reminder_IsMailSent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMailSent",
                table: "Reminders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMailSent",
                table: "Reminders");
        }
    }
}
