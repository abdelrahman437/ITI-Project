using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;

        public CourseController(ICourseService courseService,IUserService userService)
        {
            _courseService = courseService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string? search, string? category, int page = 1,int? pagesize=null)
        {

            var pagedCourses = await _courseService.GetPagedAsync(search, category, page, pagesize);
            ViewBag.Categories = await _courseService.getcategories();
            ViewBag.SelectedCategory = category;
            ViewBag.Search = search;
            return View(pagedCourses);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsyncVM(id);

            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Label = "Get By Id";
            return View(course);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Instructors = await _userService.GetInstructors();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddAsync(course);
                await _courseService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Instructors = await _userService.GetInstructors();
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _courseService.Update(course);
                    await _courseService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _courseService.GetByIdAsync(course.CourseId) != null))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id,int pagenumber = 1)
        {
            try
            {
                _courseService.Delete(id);
                await _courseService.SaveAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to delete course. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction(nameof(Index), new { page = pagenumber });
        }

        public async Task<IActionResult> IsCourseNameAvailable(string name, int courseId = 0)
        {
            var exists = await _courseService.IsNameExistAsync(name, courseId);
                

            if (exists)
            {
                return Json($"Course name '{name}' already exists.");
            }

            return Json(true);
        }

    }
}
