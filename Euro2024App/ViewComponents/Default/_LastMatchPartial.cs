using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.ViewComponents.Default
{
    public class _LastMatchPartial : ViewComponent
    {
        private readonly MatchManager _matchManager;

        public _LastMatchPartial(IMatchDal matchDal)
        {
            _matchManager = new MatchManager(matchDal);
        }
        public IViewComponentResult Invoke()
        {
            var values = _matchManager.TGetLastThreeMatches();
            return View(values);
        }
    }
}
