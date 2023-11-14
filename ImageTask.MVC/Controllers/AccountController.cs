using ImageTask.Core.Entities.Identity;
using ImageTask.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Services;

namespace ImageTask.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return NotFound();
            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Product");
            return View(model);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0]
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return RedirectToAction("Login");
            return View(model);
        }
    }
}
