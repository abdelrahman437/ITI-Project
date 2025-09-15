using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "admin@iti.com", "Admin User", 0 },
                    { 2, "omar@iti.com", "Omar Khaled", 2 },
                    { 3, "laila@iti.com", "Laila Hassan", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Category", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 1, "Programming", 1, "C# Basics" },
                    { 2, "Web Development", 1, "ASP.NET Core" },
                    { 3, "Database", 2, "SQL Fundamentals" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "CourseId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 3, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "SessionId", "TraineeId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 2, 85m },
                    { 2, 1, 3, 90m },
                    { 3, 2, 2, 78m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
