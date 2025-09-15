using System.Collections.Generic;
using System.Reflection.Emit;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<User> Users { get; set; } 
    public DbSet<Course> Courses { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // 🎓 Users (Admins, Instructors, Trainees)
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 101, Name = "Admin User", Email = "admin@iti.com", Role = UserRole.Admin },

            // Instructors
            new User { UserId = 201, Name = "Mohamed Ali", Email = "mohamed@iti.com", Role = UserRole.Instructor },
            new User { UserId = 202, Name = "Sara Nabil", Email = "sara@iti.com", Role = UserRole.Instructor },
            new User { UserId = 203, Name = "Ahmed Samir", Email = "ahmed@iti.com", Role = UserRole.Instructor },
            new User { UserId = 204, Name = "Nour Adel", Email = "nour@iti.com", Role = UserRole.Instructor },

            // Trainees
            new User { UserId = 301, Name = "Omar Khaled", Email = "omar@iti.com", Role = UserRole.Trainee },
            new User { UserId = 302, Name = "Laila Hassan", Email = "laila@iti.com", Role = UserRole.Trainee },
            new User { UserId = 303, Name = "Karim Tarek", Email = "karim@iti.com", Role = UserRole.Trainee },
            new User { UserId = 304, Name = "Huda Fathy", Email = "huda@iti.com", Role = UserRole.Trainee },
            new User { UserId = 305, Name = "Youssef Adel", Email = "youssef@iti.com", Role = UserRole.Trainee },
            new User { UserId = 306, Name = "Mona Samy", Email = "mona@iti.com", Role = UserRole.Trainee },
            new User { UserId = 307, Name = "Tamer Wael", Email = "tamer@iti.com", Role = UserRole.Trainee },
            new User { UserId = 308, Name = "Rana Hussein", Email = "rana@iti.com", Role = UserRole.Trainee },
            new User { UserId = 309, Name = "Hassan Yasser", Email = "hassan@iti.com", Role = UserRole.Trainee },
            new User { UserId = 310, Name = "Mai Salah", Email = "mai@iti.com", Role = UserRole.Trainee },
            new User { UserId = 311, Name = "Ali Fawzy", Email = "ali@iti.com", Role = UserRole.Trainee },
            new User { UserId = 312, Name = "Salma Ibrahim", Email = "salma@iti.com", Role = UserRole.Trainee },
            new User { UserId = 313, Name = "Mostafa Hany", Email = "mostafa@iti.com", Role = UserRole.Trainee }
        );

        // 📚 Courses (IDs كبيرة علشان متتعارضش)
        modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 2001, Name = "C# Basics", Category = "Programming", InstructorId = 201 },
            new Course { CourseId = 2002, Name = "ASP.NET Core", Category = "Web Development", InstructorId = 201 },
            new Course { CourseId = 2003, Name = "SQL Fundamentals", Category = "Database", InstructorId = 202 },
            new Course { CourseId = 2004, Name = "Entity Framework", Category = "ORM", InstructorId = 202 },
            new Course { CourseId = 2005, Name = "HTML & CSS", Category = "Frontend", InstructorId = 203 },
            new Course { CourseId = 2006, Name = "JavaScript", Category = "Frontend", InstructorId = 203 },
            new Course { CourseId = 2007, Name = "React Basics", Category = "Frontend", InstructorId = 203 },
            new Course { CourseId = 2008, Name = "Python Basics", Category = "Programming", InstructorId = 204 },
            new Course { CourseId = 2009, Name = "Django", Category = "Web Development", InstructorId = 204 },
            new Course { CourseId = 2010, Name = "Java OOP", Category = "Programming", InstructorId = 201 },
            new Course { CourseId = 2011, Name = "Spring Boot", Category = "Web Development", InstructorId = 201 },
            new Course { CourseId = 2012, Name = "NoSQL Databases", Category = "Database", InstructorId = 202 },
            new Course { CourseId = 2013, Name = "DevOps Basics", Category = "Tools", InstructorId = 204 },
            new Course { CourseId = 2014, Name = "Cloud Fundamentals", Category = "Cloud", InstructorId = 204 },
            new Course { CourseId = 2015, Name = "Agile Methodologies", Category = "Management", InstructorId = 202 },
            new Course { CourseId = 2016, Name = "Unit Testing", Category = "QA", InstructorId = 203 }
        );

        // 📆 Sessions (متوافقة مع CourseId)
        modelBuilder.Entity<Session>().HasData(
            Enumerable.Range(1, 16).Select(i => new Session
            {
                SessionId = 3000 + i,     // IDs تبدأ من 3001
                CourseId = 2000 + i,     // نفس أرقام الكورسات فوق
                StartDate = DateTime.Today.AddDays(i),
                EndDate = DateTime.Today.AddDays(i + 10)
            })
        );

        // 🏆 Grades (مرتبطة بالـ Sessions فوق)
        modelBuilder.Entity<Grade>().HasData(
            new Grade { GradeId = 1, SessionId = 3001, TraineeId = 301, Value = 85 },
            new Grade { GradeId = 2, SessionId = 3001, TraineeId = 302, Value = 90 },
            new Grade { GradeId = 3, SessionId = 3002, TraineeId = 301, Value = 78 },
            new Grade { GradeId = 4, SessionId = 3003, TraineeId = 303, Value = 88 },
            new Grade { GradeId = 5, SessionId = 3004, TraineeId = 304, Value = 82 },
            new Grade { GradeId = 6, SessionId = 3005, TraineeId = 305, Value = 91 },
            new Grade { GradeId = 7, SessionId = 3006, TraineeId = 306, Value = 79 },
            new Grade { GradeId = 8, SessionId = 3007, TraineeId = 307, Value = 84 },
            new Grade { GradeId = 9, SessionId = 3008, TraineeId = 308, Value = 95 },
            new Grade { GradeId = 10, SessionId = 3009, TraineeId = 309, Value = 87 },
            new Grade { GradeId = 11, SessionId = 3010, TraineeId = 310, Value = 93 },
            new Grade { GradeId = 12, SessionId = 3011, TraineeId = 311, Value = 81 },
            new Grade { GradeId = 13, SessionId = 3012, TraineeId = 312, Value = 77 },
            new Grade { GradeId = 14, SessionId = 3013, TraineeId = 313, Value = 85 },
            new Grade { GradeId = 15, SessionId = 3014, TraineeId = 301, Value = 90 },
            new Grade { GradeId = 16, SessionId = 3015, TraineeId = 302, Value = 92 },
            new Grade { GradeId = 17, SessionId = 3016, TraineeId = 303, Value = 86 },
            new Grade { GradeId = 18, SessionId = 3012, TraineeId = 304, Value = 80 },
            new Grade { GradeId = 19, SessionId = 3013, TraineeId = 305, Value = 89 },
            new Grade { GradeId = 20, SessionId = 3014, TraineeId = 306, Value = 83 }
        );


    }
}
