using Data_access_lyer.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc3.viewmodels;

namespace mvc3.Controllers
{
    [Authorize(Roles = "superadmin")]
    public class userController : Controller
	{
		private readonly UserManager<applicationuser> _usermanager;

		public userController(UserManager<applicationuser> usermanager)
		{
			_usermanager = usermanager;
		}

		public async Task< IActionResult >Index(string email)
		{
			if(string.IsNullOrEmpty(email))
			{
				var users =  await _usermanager.Users.Select(u => new userviewmodel
				{
					email = u.Email,
					firstname = u.firstname,
					lastname = u.lastname,
					username = u.UserName,
					id = u.Id,
					roles = _usermanager.GetRolesAsync(u).GetAwaiter().GetResult()

				}
					).ToListAsync();
				return View(users);
			}
			var user = await _usermanager.FindByEmailAsync(email);
			if (user is null) return View(Enumerable.Empty<userviewmodel>());
			var model = new userviewmodel
			{
				email = user.Email,
				firstname = user.firstname,
				lastname = user.lastname,
				username = user.UserName,
				id = user.Id,
				roles = await _usermanager.GetRolesAsync(user)
			};
			return View(model);
		}
		public async Task<IActionResult> details(string id, string viewname =nameof(details) )
		{
			if (string.IsNullOrEmpty(id)) return BadRequest();
			var user = await _usermanager.FindByIdAsync(id);
			if (user is null) return NotFound();
			var model = new userviewmodel
			{
                  email= user.Email,
                firstname = user.firstname,
                lastname = user.lastname,
                username = user.UserName,
                id = user.Id,
                roles = await _usermanager.GetRolesAsync(user)
            };
			return View(viewname,model);
		}
		public async Task<IActionResult> edit(string id) => await details(id,nameof(edit));
		[HttpPost]
        public async Task<IActionResult> edit(string id, userviewmodel model)
		{
			if (id != model.id) return BadRequest();
			
			if (!ModelState.IsValid) return View(model);
			try
			{
				var user = await _usermanager.FindByEmailAsync(model.email);
				if (user is null) return NotFound();
				user.firstname = model.firstname;
				user.lastname = model.lastname;
				await _usermanager.UpdateAsync(user);
				return RedirectToAction(nameof(Index));


            }
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			

			}
            return View(model);
        }
        public async Task<IActionResult> delete(string id) => await details(id, nameof(delete));
		[HttpPost]
		[ActionName("delete")]
        public async Task<IActionResult> confirmdelete(string id)
		{
            try
            {
                var user = await _usermanager.FindByIdAsync(id);
                if (user is null) return NotFound();
              
                await _usermanager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);


            }
			return View();
        }
    }
}
