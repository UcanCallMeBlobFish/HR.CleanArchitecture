using HRLeaveOut.MVC.Contracts;
using HRLeaveOut.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveOut.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UsersController(IAuthenticationService authService)
        {
            this._authService = authService;
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {


            if (ModelState.IsValid)
            {
                var isLoggedIn = await _authService.Authenticate(login.Email, login.Password);
                if (isLoggedIn)
                    return LocalRedirect("/Home/Index");

            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }

            ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
            return View(login);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registration)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authService.Register(registration);
                if (isCreated)
                    return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "Registration Attempt Failed. Please try again.");
            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}
