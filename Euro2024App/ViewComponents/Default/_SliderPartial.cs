using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
