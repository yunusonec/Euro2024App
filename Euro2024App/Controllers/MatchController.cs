using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Euro2024App.Models;
using Microsoft.EntityFrameworkCore;

namespace Euro2024App.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly ITeamService _teamService;
        private readonly ICommentService _commentService;

        public MatchController(IMatchService matchService, ITeamService teamService, ICommentService commentService)
        {
            _matchService = matchService;
            _teamService = teamService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var matches = _matchService.TGetList(); // Maçları al
            return View(matches);
        }
        public IActionResult Details(int id)
        {
            var match = _matchService.GetMatchQueryable()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Comments)
                    .ThenInclude(c => c.User)  // User bilgilerini de dahil et
                .FirstOrDefault(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }
        public IActionResult Create()
        {
            var homeTeams = _teamService.TGetList(); // Ev sahibi takımlar için listeyi al
            var awayTeams = _teamService.TGetList(); // Misafir takımlar için listeyi al

            ViewBag.HomeTeams = homeTeams;
            ViewBag.AwayTeams = awayTeams;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MatchModel model)
        {
            if (ModelState.IsValid)
            {
                var match = new Match
                {
                    HomeTeamId = model.HomeTeamId,
                    AwayTeamId = model.AwayTeamId,
                    Date = model.Date,
                    HomeTeamGoals = model.HomeTeamGoals,
                    AwayTeamGoals = model.AwayTeamGoals
                };
                _matchService.TAdd(match); // Maç ekleme işlemi
                return RedirectToAction(nameof(Index)); // Ekleme işleminden sonra liste sayfasına yönlendir
            }
            ViewBag.HomeTeams = _matchService.TGetList(); // Hatalı durumlarda tekrar takımların listesi
            ViewBag.AwayTeams = _matchService.TGetList();
            return View(model); // Model geçerli değilse tekrar formu göster
        }
    }
}
