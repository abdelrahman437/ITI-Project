using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3);

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
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 1,
                columns: new[] { "SessionId", "TraineeId" },
                values: new object[] { 3001, 301 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 2,
                columns: new[] { "SessionId", "TraineeId" },
                values: new object[] { 3001, 302 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 3,
                columns: new[] { "SessionId", "TraineeId" },
                values: new object[] { 3002, 301 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 101, "admin@iti.com", "Admin User", 0 },
                    { 201, "mohamed@iti.com", "Mohamed Ali", 1 },
                    { 202, "sara@iti.com", "Sara Nabil", 1 },
                    { 203, "ahmed@iti.com", "Ahmed Samir", 1 },
                    { 204, "nour@iti.com", "Nour Adel", 1 },
                    { 301, "omar@iti.com", "Omar Khaled", 2 },
                    { 302, "laila@iti.com", "Laila Hassan", 2 },
                    { 303, "karim@iti.com", "Karim Tarek", 2 },
                    { 304, "huda@iti.com", "Huda Fathy", 2 },
                    { 305, "youssef@iti.com", "Youssef Adel", 2 },
                    { 306, "mona@iti.com", "Mona Samy", 2 },
                    { 307, "tamer@iti.com", "Tamer Wael", 2 },
                    { 308, "rana@iti.com", "Rana Hussein", 2 },
                    { 309, "hassan@iti.com", "Hassan Yasser", 2 },
                    { 310, "mai@iti.com", "Mai Salah", 2 },
                    { 311, "ali@iti.com", "Ali Fawzy", 2 },
                    { 312, "salma@iti.com", "Salma Ibrahim", 2 },
                    { 313, "mostafa@iti.com", "Mostafa Hany", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Category", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 2001, "Programming", 201, "C# Basics" },
                    { 2002, "Web Development", 201, "ASP.NET Core" },
                    { 2003, "Database", 202, "SQL Fundamentals" },
                    { 2004, "ORM", 202, "Entity Framework" },
                    { 2005, "Frontend", 203, "HTML & CSS" },
                    { 2006, "Frontend", 203, "JavaScript" },
                    { 2007, "Frontend", 203, "React Basics" },
                    { 2008, "Programming", 204, "Python Basics" },
                    { 2009, "Web Development", 204, "Django" },
                    { 2010, "Programming", 201, "Java OOP" },
                    { 2011, "Web Development", 201, "Spring Boot" },
                    { 2012, "Database", 202, "NoSQL Databases" },
                    { 2013, "Tools", 204, "DevOps Basics" },
                    { 2014, "Cloud", 204, "Cloud Fundamentals" },
                    { 2015, "Management", 202, "Agile Methodologies" },
                    { 2016, "QA", 203, "Unit Testing" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "CourseId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 3001, 2001, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3002, 2002, new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3003, 2003, new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3004, 2004, new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3005, 2005, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3006, 2006, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3007, 2007, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3008, 2008, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3009, 2009, new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3010, 2010, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3011, 2011, new DateTime(2025, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3012, 2012, new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3013, 2013, new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3014, 2014, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3015, 2015, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3016, 2016, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "SessionId", "TraineeId", "Value" },
                values: new object[,]
                {
                    { 4, 3003, 303, 88m },
                    { 5, 3004, 304, 82m },
                    { 6, 3005, 305, 91m },
                    { 7, 3006, 306, 79m },
                    { 8, 3007, 307, 84m },
                    { 9, 3008, 308, 95m },
                    { 10, 3009, 309, 87m },
                    { 11, 3010, 310, 93m },
                    { 12, 3011, 311, 81m },
                    { 13, 3012, 312, 77m },
                    { 14, 3013, 313, 85m },
                    { 15, 3014, 301, 90m },
                    { 16, 3015, 302, 92m },
                    { 17, 3016, 303, 86m },
                    { 18, 3012, 304, 80m },
                    { 19, 3013, 305, 89m },
                    { 20, 3014, 306, 83m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3001);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3006);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3007);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3008);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3009);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3010);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3011);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3012);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3013);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3014);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3015);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 3016);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2004);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2005);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2006);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2007);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2008);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2009);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2010);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2011);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2012);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2013);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2014);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2015);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2016);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 204);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 1,
                columns: new[] { "SessionId", "TraineeId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 2,
                columns: new[] { "SessionId", "TraineeId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 3,
                columns: new[] { "SessionId", "TraineeId" },
                values: new object[] { 2, 2 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }
    }
}
