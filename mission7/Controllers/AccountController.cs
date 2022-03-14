﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mission7.Models.ViewModels;

namespace mission7.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            userManager = um;
            signInManager = sim;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            IdentityUser user = await userManager.FindByNameAsync(loginModel.Username);

            if (user != null)
            {
                await signInManager.SignOutAsync();

                if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                {
                    return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout (string returnUrl = "/")
        {
            await signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }
    }
}