using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividuelltDatabasProjektTess.Migrations
{
    /// <inheritdoc />
    public partial class Enrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D718757FA10D7", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professi__3F309E1F3F1E1B49", x => x.ProfessionID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionID = table.Column<int>(type: "int", nullable: true),
                    SocialSecurityNumber = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<long>(type: "bigint", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__96D4AAF7B5E1CEF4", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SocialSecurityNumber = table.Column<long>(type: "bigint", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialSecurityNumber = table.Column<long>(type: "bigint", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__32C52A79451E8EB7", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Course_Teacher",
                columns: table => new
                {
                    FK_CourseID = table.Column<int>(type: "int", nullable: true),
                    FK_TeacherID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Course_Teacher_CourseID",
                        column: x => x.FK_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "Course_Teacher_TeacherID",
                        column: x => x.FK_TeacherID,
                        principalTable: "Staff",
                        principalColumn: "StaffID");
                });

            migrationBuilder.CreateTable(
                name: "Staff_Professions",
                columns: table => new
                {
                    FK_StaffID = table.Column<int>(type: "int", nullable: true),
                    FK_ProfessionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Staff_Professions_ProfessionID",
                        column: x => x.FK_ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ProfessionID");
                    table.ForeignKey(
                        name: "FK_Staff_Professions_StaffID",
                        column: x => x.FK_StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID");
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    FK_StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grade__54F87A3742BCA43F", x => x.GradeID);
                    table.ForeignKey(
                        name: "Grade_StudentID",
                        column: x => x.FK_StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    FK_StudentID = table.Column<int>(type: "int", nullable: true),
                    FK_CourseID = table.Column<int>(type: "int", nullable: true),
                    FK_GradeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CourseID_Enrollment",
                        column: x => x.FK_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_Grade_Enrollment",
                        column: x => x.FK_GradeID,
                        principalTable: "Grade",
                        principalColumn: "GradeID");
                    table.ForeignKey(
                        name: "FK_StudentID_Enrollment",
                        column: x => x.FK_StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "GradeDetails",
                columns: table => new
                {
                    GradeDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_GradeID = table.Column<int>(type: "int", nullable: true),
                    FK_StudentID = table.Column<int>(type: "int", nullable: true),
                    FK_CourseID = table.Column<int>(type: "int", nullable: true),
                    SetDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GradeDet__41C6FC3E4D75C72A", x => x.GradeDetailID);
                    table.ForeignKey(
                        name: "GradeDetails_FK_CourseID",
                        column: x => x.FK_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "GradeDetails_FK_Grade",
                        column: x => x.FK_GradeID,
                        principalTable: "Grade",
                        principalColumn: "GradeID");
                    table.ForeignKey(
                        name: "GradeDetails_StudentID",
                        column: x => x.FK_StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teacher_FK_CourseID",
                table: "Course_Teacher",
                column: "FK_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teacher_FK_TeacherID",
                table: "Course_Teacher",
                column: "FK_TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_FK_CourseID",
                table: "Enrollment",
                column: "FK_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_FK_GradeID",
                table: "Enrollment",
                column: "FK_GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_FK_StudentID",
                table: "Enrollment",
                column: "FK_StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_FK_StudentID",
                table: "Grade",
                column: "FK_StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDetails_FK_CourseID",
                table: "GradeDetails",
                column: "FK_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDetails_FK_GradeID",
                table: "GradeDetails",
                column: "FK_GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDetails_FK_StudentID",
                table: "GradeDetails",
                column: "FK_StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Professions_FK_ProfessionID",
                table: "Staff_Professions",
                column: "FK_ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Professions_FK_StaffID",
                table: "Staff_Professions",
                column: "FK_StaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Teacher");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "GradeDetails");

            migrationBuilder.DropTable(
                name: "Staff_Professions");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
