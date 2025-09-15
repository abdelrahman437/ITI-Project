using System.Threading.Tasks;
using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.BLL.ViewModel;
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
        public async Task<IActionResult> Index(string search, int page = 1, int? pagesize = null)
        {
            var x = await _sessionService.GetAllAsync(search, page, pagesize);
            ViewBag.Search = search;
            return View(x);
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



            await _sessionService.CreateSessionAsync(model);
            TempData["SuccessMessage"] = "Session created successfully!";
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var session = await _sessionService.GetSessionAsync(id);
            if (session == null) return NotFound();

            ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name");

            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Session model)
        {
            ViewBag.Courses = new SelectList(await _courseService.GetAllAsync(), "CourseId", "Name");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _sessionService.UpdateSessionAsync(model);
                if (!result)
                {
                    ModelState.AddModelError("", "Could not update session.");
                    return View(model);
                }

                TempData["SuccessMessage"] = "Session updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // تسجل الخطأ في Logs (ممكن تستخدم ILogger)
                ModelState.AddModelError("", $"An error occurred while updating the session: {ex.Message}");
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, int pagenumber = 1)
        {
            try
            {
                await _sessionService.DeleteSessionAsync(id);
                TempData["SuccessMessage"] = "Session deleted successfully!";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Unable to delete session. It may be related to other data.";
            }
            return RedirectToAction(nameof(Index), new { page = pagenumber });
        }

        public async Task<IActionResult> Details(int id)
        {
            var session = await _sessionService.GetSessionAsyncVM(id);
            if (session == null)
            {
                return NotFound();
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
