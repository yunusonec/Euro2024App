using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.Areas.AdminArea.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
