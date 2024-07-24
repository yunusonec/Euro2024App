using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.ViewComponents.Default
{
    public class _LastMatchPartial : ViewComponent
    {
        private readonly MatchManager _matchManager;

        public _LastMatchPartial()
        {
            _matchManager = new MatchManager(new EfMatchDal());
        }
        public IViewComponentResult Invoke()
        {
            var values = _matchManager.TGetLastThreeMatches();
            return View(values);
        }
    }
}
