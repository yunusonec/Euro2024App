using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Euro2024App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Euro2024App.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly ICoachService _coachService;

        public TeamController(ITeamService teamService, ICoachService coachService)
        {
            _teamService = teamService;
            _coachService = coachService;
        }

        public IActionResult Index()
        {
            var teams = _teamService.TGetList();
            return View(teams);
        }
        // Yeni eylem metodu: Detaylar
        public IActionResult Details(int id)
        {
            var team = _teamService.GetByID(id);
            if (team == null)
            {
                return NotFound();
            }

            var players = _teamService.GetPlayersByTeamId(id);
            var coach = _teamService.GetCoachByTeamId(id);

            var model = new TeamDetailsViewModel
            {
                Team = team,
                Players = players,
                Coach = coach
            };

            return View("Details", model);
        }
        public IActionResult Create()
        {
            var allCoaches = _coachService.TGetList(); // Tüm teknik direktörleri alın
            var teams = _teamService.TGetList(); // Tüm takımları alın
            var teamCoachIds = teams.Select(t => t.CoachId).ToHashSet(); // Takımı olan teknik direktörlerin ID'lerini alın


            if (allCoaches == null)
            {
                ViewBag.CoachList = new List<SelectListItem>(); // Boş bir liste döndürün
            }

            ViewBag.CoachList = allCoaches.Select(c => new SelectListItem
            {
                Value = c.CoachId.ToString(),
                Text = c.Name,
                Disabled = teamCoachIds.Contains(c.CoachId) // Teknik direktör takımı olanlardan biri ise seçilemez yap
            }).ToList(); // Seçim listesini oluşturun

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                var team = new Team
                {
                    Name = model.Name,
                    PhotoUrl = model.PhotoUrl,
                    CoachId = model.CoachId
                };
                _teamService.TAdd(team);
                return RedirectToAction(nameof(Index));
            }

            // Eğer model geçerli değilse, koçları tekrar ViewBag'e ekleyin
            ViewBag.CoachList = _coachService.TGetList().Select(c => new SelectListItem
            {
                Value = c.CoachId.ToString(),  // CoachId veya uygun bir anahtar kullanın
                Text = c.Name
            }).ToList();

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var team = _teamService.GetByID(id);
            if (team == null)
            {
                return NotFound();
            }

            var coaches = _coachService.TGetList()
       .Where(c => c.Team == null || c.Team.TeamId == id)
       .ToList();

            if (coaches == null)
            {
                ViewBag.CoachList = new SelectList(new List<SelectListItem>(), "Id", "Name");
            }
            else
            {
                ViewBag.CoachList = new SelectList(coaches, "CoachId", "Name");
            }


            var model = new TeamModel
            {
                Id = team.TeamId,
                Name = team.Name,
                PhotoUrl = team.PhotoUrl,
                CoachId = team.CoachId
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                var team = _teamService.GetByID(model.Id);
                if (team == null)
                {
                    return NotFound();
                }

                team.Name = model.Name;
                team.PhotoUrl = model.PhotoUrl;
                team.CoachId = model.CoachId;
                _teamService.TUpdate(team);

                return RedirectToAction(nameof(Index));
            }

            var coaches = _coachService.TGetList().Where(c => c.Team == null || c.Team.TeamId == model.Id).ToList();
            ViewBag.CoachList = new SelectList(coaches, "Id", "Name");

            return View(model);
        }
    }
}
