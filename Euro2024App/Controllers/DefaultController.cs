using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<Match>();
            return View(model);
        }
    }
}
