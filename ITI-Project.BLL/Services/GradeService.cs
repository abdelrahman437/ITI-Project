using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.Helpers;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.BLL.Settings;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ITI_Project.BLL.Services
{

    public class GradeService: IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<PaginationSetting> _settings;

        public GradeService(IUnitOfWork unitOfWork, IOptions<PaginationSetting> settings)
        {
            _unitOfWork = unitOfWork;
            _settings = settings;
        }

        public async Task<List<GradeViewModel>> GetGradesPerTrainee(int id)
        {
            return await _unitOfWork.Grades.GetAllAsQueryable().Where(e=>e.TraineeId == id).Include(e => e.Trainee).Select(
            s => new GradeViewModel
            {
                GradeId = s.GradeId,
                SessionId = s.Session.SessionId,
                CourseName = s.Session.Course.Name,
                StartDate = s.Session.StartDate,
                EndDate = s.Session.EndDate,
                Value = s.Value
            }).ToListAsync();
        }
        public async Task<Pagination<UserViewModel>> UsersWithGrades(int pageIndex, int? pageSize)
        {
            var result = _unitOfWork.Users
                .GetAllAsQueryable()
                .OrderBy(t => t.Name)
                .Where(e=>e.Role == DAL.Models.Enums.UserRole.Trainee)
                .Select(t => new UserViewModel
                {
                    UserId = t.UserId,
                    Name = t.Name,
                    Email = t.Email,
                    grades = t.Grades 
                        .Select(g => new GradeViewModel
                        {
                            GradeId = g.GradeId,
                            SessionId = g.Session.SessionId,
                            CourseName = g.Session.Course.Name,
                            StartDate = g.Session.StartDate,
                            EndDate = g.Session.EndDate,
                            Value = g.Value
                        })
                        .ToList()
                });


            int defaultPageSize = _settings.Value.PageSize;
            int effectivePageSize = pageSize ?? defaultPageSize;
            return await Pagination<UserViewModel>.CreateAsync(result, pageIndex, effectivePageSize);

        }

        public async Task AddGradeAsync(int traineeId, int sessionId, decimal value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Grade must be between 0 and 100");

            var grade = new Grade
            {
                TraineeId = traineeId,
                SessionId = sessionId,
                Value = value
            };

            await _unitOfWork.Grades.AddAsync(grade);
            await _unitOfWork.CompleteAsync();
        }

    }
}
