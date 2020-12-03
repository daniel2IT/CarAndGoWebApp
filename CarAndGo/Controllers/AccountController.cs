using CarAndGo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager; /* UserManager API CRUD operations .. Delete, Create .. */
        private readonly SignInManager<IdentityUser> _signInManager; /*  SignInManger API , for LogIn , SignUp , LogOut etc.. */

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // Login method ... 2 action results  .. 1 - > Redirect user to LoginPage, RegisterPage ...2 -> handle login
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) /* Validation */
            {
                return View(loginViewModel); /* Redirect to same page .. */
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName); /* get from list users one of = typedToFieldName... */

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false); /* If User exists , get password */
                if (result.Succeeded) /* */
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(loginViewModel.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Username/password not found");
            return View(loginViewModel);
        }
    }
}
