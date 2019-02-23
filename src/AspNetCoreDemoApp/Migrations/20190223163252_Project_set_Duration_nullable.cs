using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreDemoApp.Migrations
{
    public partial class Project_set_Duration_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
