using Data_access_lyer.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc3.viewmodels;
using mvc3.utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace mvc3.Controllers
{
    public class accountController : Controller
    {
        private readonly UserManager<applicationuser> _user;
        private readonly SignInManager<applicationuser> _signin;

        public accountController(UserManager<applicationuser> user, SignInManager<applicationuser> signin)
        {
            _user = user;
            _signin = signin;
        }


        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(registerviewmodel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new applicationuser
            {
                UserName = model.username,
                firstname = model.firstname,
                lastname = model.lastname,
                Email = model.email,
                PasswordHash = model.password,

            };
            var result = _user.CreateAsync(user, model.password).Result;
            if (result.Succeeded)
                return RedirectToAction(nameof(login));
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(loginviewmodel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = _user.FindByEmailAsync(model.email).Result;
            if (user is not null)
            {
                if (_user.CheckPasswordAsync(user, model.password).Result)
                {
                    var result = _signin.PasswordSignInAsync(user, model.password, model.rememberme, false).Result;
                    if (result.Succeeded) return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
                }

            }
            ModelState.AddModelError(string.Empty, "in valid email or password");
            return View(model);
        }
        public new IActionResult SignOut()
        {
            _signin.SignOutAsync();
            return RedirectToAction(nameof(login));
        }
        public IActionResult forgetpassword()
        {
            return View();
        }
       [HttpPost]
     public IActionResult forgetpassword(forgetpasswordviewmodel model)
       {
        if (!ModelState.IsValid) return View(model);
      var user = _user.FindByEmailAsync(model.email).Result;
        if(user is not null)
       {
                var token = _user.GeneratePasswordResetTokenAsync(user).Result;
                var url = Url.Action(nameof(resetpassword), nameof(accountController).Replace("Controller", string.Empty), new { token = token, email = model.email }, Request.Scheme);
                var email = new mail
                {
                    subject = "reset password",
                    body = url,
                    recipient = model.email
                };
                //todo
                mailsetting.sendemail(email);
                return View(nameof(checkyouremail));
       }
            ModelState.AddModelError(string.Empty, "user not found");
            return View(model);

      }
      
		public IActionResult  checkyouremail()
		{
			return View();
		}
		public IActionResult resetpassword (string email, string token)
		{ if (email is null || token is null) return BadRequest();
            TempData["email"] = email;
            TempData["token"] = token;
			return View();
		}
        [HttpPost]
        public IActionResult resetpassword(resetpasswordviewmodel model)
        {
            model.token = TempData["token"]?.ToString() ?? string.Empty;
            model.email = TempData["email"]?.ToString() ?? string.Empty;
            if (!ModelState.IsValid) return View(model);
            var user = _user.FindByEmailAsync(model.email).Result;
            if(user != null)
            {
                var result = _user.ResetPasswordAsync(user, model.token, model.password).Result;
                if (result.Succeeded) return RedirectToAction(nameof(login));
              foreach(var item in result.Errors)
                
                    ModelState.AddModelError(string.Empty, item.Description);
                
            }
            ModelState.AddModelError(string.Empty, " user not found");
            return View(model);
           
        }

	}
}

