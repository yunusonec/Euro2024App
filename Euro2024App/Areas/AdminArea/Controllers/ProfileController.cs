using EntityLayer.Concrete;
using Euro2024App.Areas.AdminArea.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.email = values.Email;
            return View(userEditViewModel);
        }
        [HttpPost]  
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name=p.name;
            user.Surname = p.surname;
            user.Email = p.email;
            user.PhoneNumber = p.phonenumber;
            

            if (!string.IsNullOrEmpty(p.password) && p.password == p.confirmpassword)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            }
            else if (!string.IsNullOrEmpty(p.password) && p.password != p.confirmpassword)
            {
                ModelState.AddModelError("", "Şifreler uyuşmuyor.");
                return View(p);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "AdminArea" }); // Başarıyla güncellendiğinde profil sayfasına geri dön
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(p);
            }
        }
    }
}
