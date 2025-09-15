using System;
using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Services;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.BLL.Settings;
using ITI_Project.DAL.Repository;
using ITI_Project.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.Configure<PaginationSetting>(
                 builder.Configuration.GetSection("Pagination"));

            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IGradeService, GradeService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
