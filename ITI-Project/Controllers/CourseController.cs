using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.DAL.Models;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;

        public CourseController(ICourseService courseService, IUserService userService)
        {
            _courseService = courseService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string? search, string? category, int page = 1, int? pagesize = null)
        {
            try
            {
                var pagedCourses = await _courseService.GetPagedAsync(search, category, page, pagesize);
                ViewBag.Categories = await _courseService.getcategories();
                ViewBag.SelectedCategory = category;
                ViewBag.Search = search;
                return View(pagedCourses);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to load courses list: {ex.Message}";
                return View("Error", new ErrorViewModel());
            }
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var course = await _courseService.GetByIdAsyncVM(id);
                if (course == null)
                {
                    TempData["ErrorMessage"] = "Course not found.";
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Label = "Get By Id";
                return View(course);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to retrieve course: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Instructors = await _userService.GetInstructors();
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to load instructors: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _courseService.AddAsync(course);
                    await _courseService.SaveAsync();
                    TempData["SuccessMessage"] = "Course added successfully ✅";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while creating course: {ex.Message}";
            }
            ViewBag.Instructors = await _userService.GetInstructors();
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var course = await _courseService.GetByIdAsync(id);
                if (course == null)
                {
                    TempData["ErrorMessage"] = "Course not found.";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Instructors = await _userService.GetInstructors();
                return View(course);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to load course: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId) return NotFound();

            try
            {
                if (ModelState.IsValid)
                {
                    _courseService.Update(course);
                    await _courseService.SaveAsync();
                    TempData["SuccessMessage"] = "Course updated successfully ✅";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _courseService.GetByIdAsync(course.CourseId) != null))
                    return NotFound();
                throw;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while updating course: {ex.Message}";
            }

            ViewBag.Instructors = await _userService.GetInstructors();
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int pagenumber = 1)
        {
            try
            {
                _courseService.Delete(id);
                await _courseService.SaveAsync();
                TempData["SuccessMessage"] = "Course deleted successfully ✅";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Cannot delete course. It may have related data.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while deleting course: {ex.Message}";
            }
            return RedirectToAction(nameof(Index), new { page = pagenumber });
        }

        public async Task<IActionResult> IsCourseNameAvailable(string name, int courseId = 0)
        {
            try
            {
                var exists = await _courseService.IsNameExistAsync(name, courseId);
                if (exists)
                    return Json($"Course name '{name}' already exists.");
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json($"Error while checking name: {ex.Message}");
            }
        }
    }
}
