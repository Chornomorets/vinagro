using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreDemoApp.Migrations
{
    public partial class Fixing_typo_FK_Institute_for_Mentor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_Institute_FK_Intitute",
                table: "Mentor");

            migrationBuilder.RenameColumn(
                name: "FK_Intitute",
                table: "Mentor",
                newName: "FK_Institute");

            migrationBuilder.RenameIndex(
                name: "IX_Mentor_FK_Intitute",
                table: "Mentor",
                newName: "IX_Mentor_FK_Institute");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_Institute_FK_Institute",
                table: "Mentor",
                column: "FK_Institute",
                principalTable: "Institute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_Institute_FK_Institute",
                table: "Mentor");

            migrationBuilder.RenameColumn(
                name: "FK_Institute",
                table: "Mentor",
                newName: "FK_Intitute");

            migrationBuilder.RenameIndex(
                name: "IX_Mentor_FK_Institute",
                table: "Mentor",
                newName: "IX_Mentor_FK_Intitute");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_Institute_FK_Intitute",
                table: "Mentor",
                column: "FK_Intitute",
                principalTable: "Institute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
