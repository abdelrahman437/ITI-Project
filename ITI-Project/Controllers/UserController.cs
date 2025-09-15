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
            try
            {
                var pagedUsers = await _userService.GetAllAsync(search, role, pageNumber, pagesize);
                ViewBag.Role = role;
                ViewBag.Search = search;
                return View(pagedUsers);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to load users: {ex.Message}";
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            try
            {
                await _userService.AddAsync(user);
                TempData["SuccessMessage"] = "User added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to add user: {ex.Message}";
                return View(user);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to load user: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(user);

            try
            {
                await _userService.UpdateAsync(user);
                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                TempData["ErrorMessage"] = "Another process updated this user. Please reload and try again.";
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to update user: {ex.Message}";
                return View(user);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int pageNumber = 1)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                if (result)
                    TempData["SuccessMessage"] = "User deleted successfully!";
                else
                    TempData["ErrorMessage"] = "User not found.";

                return RedirectToAction(nameof(Index), new { pageNumber });
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Unable to delete user. They may be linked to other data.";
                return RedirectToAction(nameof(Index), new { pageNumber });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to delete user: {ex.Message}";
                return RedirectToAction(nameof(Index), new { pageNumber });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsyncVM(id);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to load user details: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> CheckEmail(string email, int userId = 0)
        {
            try
            {
                var isUnique = await _userService.IsEmailUniqueAsync(email, userId);
                if (!isUnique)
                    return Json($"Email '{email}' is already in use.");

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json($"Error while checking email: {ex.Message}");
            }
        }
    }
}
