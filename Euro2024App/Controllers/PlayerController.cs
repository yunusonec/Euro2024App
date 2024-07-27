using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            var players = _playerService.TGetList();
            return View(players);
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.TAdd(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }
        public IActionResult Edit(int id)
        {
            var player = _playerService.GetByID(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.TUpdate(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }
        public IActionResult Delete(int id)
        {
            var player = _playerService.GetByID(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var player = _playerService.GetByID(id);
            if (player != null)
            {
                _playerService.TDelete(player);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
