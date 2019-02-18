using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspNetCoreDemoApp.Migrations
{
    public partial class InitializingAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Institute",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 100, nullable: true),
                    FK_Intitute = table.Column<long>(nullable: false),
                    Position = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mentor_Institute_FK_Intitute",
                        column: x => x.FK_Intitute,
                        principalTable: "Institute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 350, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Website = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    FK_Intitute = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Institute_FK_Intitute",
                        column: x => x.FK_Intitute,
                        principalTable: "Institute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FK_Mentor = table.Column<long>(nullable: false),
                    FK_Partner = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ProjectCategory = table.Column<string>(maxLength: 50, nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_Mentor_FK_Mentor",
                        column: x => x.FK_Mentor,
                        principalTable: "Mentor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Partner_FK_Partner",
                        column: x => x.FK_Partner,
                        principalTable: "Partner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorRequest",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FK_Mentor = table.Column<long>(nullable: false),
                    FK_Project = table.Column<long>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MentorRequest_Mentor_FK_Mentor",
                        column: x => x.FK_Mentor,
                        principalTable: "Mentor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorRequest_Project_FK_Project",
                        column: x => x.FK_Project,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student2Project",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FK_Student = table.Column<long>(nullable: false),
                    FK_Project = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student2Project", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student2Project_Project_FK_Project",
                        column: x => x.FK_Project,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student2Project_Student_FK_Student",
                        column: x => x.FK_Student,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_FK_Intitute",
                table: "Mentor",
                column: "FK_Intitute");

            migrationBuilder.CreateIndex(
                name: "IX_MentorRequest_FK_Mentor",
                table: "MentorRequest",
                column: "FK_Mentor");

            migrationBuilder.CreateIndex(
                name: "IX_MentorRequest_FK_Project",
                table: "MentorRequest",
                column: "FK_Project");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FK_Mentor",
                table: "Project",
                column: "FK_Mentor");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FK_Partner",
                table: "Project",
                column: "FK_Partner");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FK_Intitute",
                table: "Student",
                column: "FK_Intitute");

            migrationBuilder.CreateIndex(
                name: "IX_Student2Project_FK_Project",
                table: "Student2Project",
                column: "FK_Project");

            migrationBuilder.CreateIndex(
                name: "IX_Student2Project_FK_Student",
                table: "Student2Project",
                column: "FK_Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorRequest");

            migrationBuilder.DropTable(
                name: "Student2Project");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Institute",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
