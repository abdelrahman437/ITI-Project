using System.Threading.Tasks;
using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly ICourseService _courseService;

        public SessionController(ISessionService sessionService, ICourseService courseService)
        {
            _sessionService = sessionService;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index(string? search, int page = 1, int? pagesize = null)
        {
            var sessions = await _sessionService.GetAllAsync(search, page, pagesize);
            ViewBag.Search = search;
            return View(sessions);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name");
            return View(new Session
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Session model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name", model.CourseId);
                return View(model);
            }

            try
            {
                var created = await _sessionService.CreateSessionAsync(model);
                if (created)
                {
                    TempData["SuccessMessage"] = "Session created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = "Failed to create session.";
                ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name", model.CourseId);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error occurred while creating session: {ex.Message}";
                ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name", model.CourseId);
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var session = await _sessionService.GetSessionAsync(id);
            if (session == null)
            {
                TempData["ErrorMessage"] = "Session not found.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name", session.CourseId);
            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Session model)
        {
            ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name", model.CourseId);

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var updated = await _sessionService.UpdateSessionAsync(model);
                if (updated)
                {
                    TempData["SuccessMessage"] = "Session updated successfully!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Could not update session. It may not exist.";
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error occurred while updating session: {ex.Message}";
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int pagenumber = 1)
        {
            try
            {
                var deleted = await _sessionService.DeleteSessionAsync(id);
                TempData["SuccessMessage"] = deleted
                    ? "Session deleted successfully!"
                    : "Session not found.";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Unable to delete session. It may be related to other data.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error occurred while deleting session: {ex.Message}";
            }

            return RedirectToAction(nameof(Index), new { page = pagenumber });
        }

        public async Task<IActionResult> Details(int id)
        {
            var session = await _sessionService.GetSessionAsyncVM(id);
            if (session == null)
            {
                TempData["ErrorMessage"] = "Session not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(session);
        }

        [HttpGet]
        public async Task<JsonResult> GetSessionsByCourse(int courseId)
        {
            var sessions = await _sessionService.GetByCourseId(courseId);
            var result = sessions.Select(s => new
            {
                sessionId = s.SessionId,
                startDate = s.StartDate,
                endDate = s.EndDate
            });
            return Json(result);
        }
    }
}
