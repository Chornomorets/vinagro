using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreDemoApp.Migrations
{
    public partial class Fixing_typo_FK_Institute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Institute_FK_Intitute",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "FK_Intitute",
                table: "Student",
                newName: "FK_Institute");

            migrationBuilder.RenameIndex(
                name: "IX_Student_FK_Intitute",
                table: "Student",
                newName: "IX_Student_FK_Institute");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Institute_FK_Institute",
                table: "Student",
                column: "FK_Institute",
                principalTable: "Institute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Institute_FK_Institute",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "FK_Institute",
                table: "Student",
                newName: "FK_Intitute");

            migrationBuilder.RenameIndex(
                name: "IX_Student_FK_Institute",
                table: "Student",
                newName: "IX_Student_FK_Intitute");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Institute_FK_Intitute",
                table: "Student",
                column: "FK_Intitute",
                principalTable: "Institute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
