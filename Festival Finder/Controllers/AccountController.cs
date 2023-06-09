﻿using Festival_Finder.Data;
using Festival_Finder.Models;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Festival_Finder.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var identityUser = new AppUser
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            var result = await userManager.CreateAsync(identityUser, registerViewModel.Password);

            if (result.Succeeded)
            {
                //Assign User role
                //var roleResult = await userManager.AddToRoleAsync(identityUser, "User");
                var roles = new List<string> { UserRoles.User };

                if (registerViewModel.IsAdmin)
                {
                    roles.Add(UserRoles.Admin);
                }

                result = await userManager.AddToRolesAsync(identityUser, roles);


                if (result.Succeeded && result != null)
                {
                    TempData["success"] = "Register successful";
                    return RedirectToAction("Login");
                }

            }

            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            var loginResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);
            if (loginResult != null && loginResult.Succeeded)
            {
                TempData["success"] = "Login successful";
                return RedirectToAction("Index", "Festival");
            }
            TempData["Error"] = "Register unsuccessful";
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData["success"] = "Logout successful";
            return Redirect("Login");
        }
    }
}
