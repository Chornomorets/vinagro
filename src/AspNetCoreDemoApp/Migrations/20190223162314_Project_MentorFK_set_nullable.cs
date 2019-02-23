using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreDemoApp.Migrations
{
    public partial class Project_MentorFK_set_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Mentor_FK_Mentor",
                table: "Project");

            migrationBuilder.AlterColumn<long>(
                name: "FK_Mentor",
                table: "Project",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Mentor_FK_Mentor",
                table: "Project",
                column: "FK_Mentor",
                principalTable: "Mentor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Mentor_FK_Mentor",
                table: "Project");

            migrationBuilder.AlterColumn<long>(
                name: "FK_Mentor",
                table: "Project",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Mentor_FK_Mentor",
                table: "Project",
                column: "FK_Mentor",
                principalTable: "Mentor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
