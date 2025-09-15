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
       
        // 🎓 Users (Admins, Trainees)
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Admin User", Email = "admin@iti.com", Role = UserRole.Admin },
            new User { UserId = 2, Name = "Omar Khaled", Email = "omar@iti.com", Role = UserRole.Trainee },
            new User { UserId = 3, Name = "Laila Hassan", Email = "laila@iti.com", Role = UserRole.Trainee }
        );

        // 📚 Courses
        modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 1, Name = "C# Basics", Category = "Programming", InstructorId = 1 },
            new Course { CourseId = 2, Name = "ASP.NET Core", Category = "Web Development", InstructorId = 1 },
            new Course { CourseId = 3, Name = "SQL Fundamentals", Category = "Database", InstructorId = 2 }
        );

        // 📆 Sessions
        modelBuilder.Entity<Session>().HasData(
            new Session { SessionId = 1, CourseId = 1, StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(10) },
            new Session { SessionId = 2, CourseId = 2, StartDate = DateTime.Today.AddDays(3), EndDate = DateTime.Today.AddDays(13) },
            new Session { SessionId = 3, CourseId = 3, StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(15) }
        );

        // 🏆 Grades
        modelBuilder.Entity<Grade>().HasData(
            new Grade { GradeId = 1, SessionId = 1, TraineeId = 2, Value = 85 },
            new Grade { GradeId = 2, SessionId = 1, TraineeId = 3, Value = 90 },
            new Grade { GradeId = 3, SessionId = 2, TraineeId = 2, Value = 78 }
        );
    }
}
