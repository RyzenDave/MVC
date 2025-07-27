using Microsoft.AspNetCore.Mvc;
using VROS.DataAccess.Interfaces;
using VROS.Dto;
using VROS.Services.Interfaces;
using VROS.VM;

namespace VideoRentalOnlineStore.app.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)  
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userService.ValidateUserAsync(vm.Email, vm.CardNumber);
            if (user == null)
            {
                ModelState.AddModelError("", "No user found with this Card Number and Email combination.");
                return View(vm);
            }

            // Login successful
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("FullName", user.FullName);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                await _userService.RegisterUserAsync(dto);
                TempData["Success"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("FullName");
            return RedirectToAction("Login");
        }
    }
}
