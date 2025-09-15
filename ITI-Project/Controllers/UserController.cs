using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index(string? search, UserRole? role, int pageNumber = 1, int? pagesize = null)
        {
            var pagedUsers = await _userService.GetAllAsync(search, role, pageNumber, pagesize);
            ViewBag.Role = role;
            ViewBag.search = search;
            return View(pagedUsers);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            await _userService.AddAsync(user);
            TempData["Success"] = "User added successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(user);

            await _userService.UpdateAsync(user);
            TempData["Success"] = "User updated successfully!";
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id, int pageNumber = 1)
        {
            var result = await _userService.DeleteAsync(id);
            TempData[result ? "Success" : "Error"] = result ? "User deleted successfully!" : "User not found.";
            return RedirectToAction(nameof(Index), new { pageNumber = pageNumber });
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetByIdAsyncVM(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> CheckEmail(string email, int userId = 0)
        {
            var isUnique = await _userService.IsEmailUniqueAsync(email, userId);

            if (!isUnique)
            {
                return Json($"Email '{email}' is already in use.");
            }

            return Json(true);
        }
    }
}
