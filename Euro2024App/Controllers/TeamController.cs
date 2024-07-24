using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Euro2024App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.Controllers
{
    public class TeamController : Controller
    {
        private readonly TeamManager _teamManager;

        public TeamController()
        {
            _teamManager = new TeamManager(new EfTeamDal(new Context()));
        }
        public IActionResult Index()
        {
            var teams = _teamManager.TGetList();
            return View(teams);
        }
        // Yeni eylem metodu: Detaylar
        public IActionResult Details(int id)
        {
            var team = _teamManager.GetByID(id);
            if (team == null)
            {
                return NotFound();
            }

            var players = _teamManager.GetPlayersByTeamId(id);
            var coach = _teamManager.GetCoachByTeamId(id);

            var model = new TeamDetailsViewModel
            {
                Team = team,
                Players = players,
                Coach = coach
            };

            return View("Details", model);
        }
    }
}
