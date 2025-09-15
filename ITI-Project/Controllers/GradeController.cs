using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_Project.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly ICourseService _courseService;
        private readonly IUserService _UserService;

        public GradeController(IGradeService gradeService, ICourseService courseService, IUserService userService)
        {
            _gradeService = gradeService;
            _courseService = courseService;
            _UserService = userService;
        }

        public async Task<IActionResult> Index(int? size = null ,int pageNumber = 1)
        {
            var model = await _gradeService.UsersWithGrades(pageNumber,size);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RecordGrade(int traineeId)
        {
            var trainee = await _UserService.GetByIdAsync(traineeId);
            if (trainee == null)
                return NotFound();

            var courses = await _courseService.GetCoursesName();
            var courseListItems = courses.Select(c => new SelectListItem
            {
                Value = c.CourseId.ToString(),
                Text = c.Name
            }).ToList();


            var model = new RecordGradeViewModel
            {
                TraineeId = trainee.UserId,
                TraineeName = trainee.Name,
                Courses = courseListItems
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecordGrade(RecordGradeViewModel model)
        {
            if (!ModelState.IsValid || model.Value < 0 || model.Value > 100)
            {
                ModelState.AddModelError("Value", "Grade must be between 0 and 100");
                return RedirectToAction(nameof(RecordGrade), new { model.TraineeId });
            }

            try
            {
                await _gradeService.AddGradeAsync(model.TraineeId, model.SelectedSessionId, model.Value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ModelState.AddModelError("Value", ex.Message);
                return RedirectToAction(nameof(RecordGrade), new { model.TraineeId });
            }

            return RedirectToAction("Index");
        }


    }
}
