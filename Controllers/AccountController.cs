using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TShirtCompany.Models;
//my this is aow
namespace TShirtCompany.Controllers
{
    public class AccountController : Controller
    {   
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            //it's not the good way to seed user i know :D
            // even pass have to be in user secrets but just for testing
            var user = new IdentityUser { UserName = "sheriffelwany@gmail.com", Email = "Sheriff@gmail.com" };
            var result = await userManager.CreateAsync(user, /*configuration["AdminPass"]*/ "Test.123456");
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError("", error.Description);
            //}

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction(ReturnUrl);
                    }else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    
                }
              
                    ModelState.AddModelError("", "Invalid Login");
                
            }
            return View(model);
        }
    }

    
}
