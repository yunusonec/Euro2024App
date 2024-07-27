using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024App.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int matchId, string text)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Kullanıcı bulunamazsa bir hata sayfasına yönlendirebilirsiniz
                return RedirectToAction("Login", "Account");
            }

            var comment = new Comment
            {
                MatchId = matchId,
                UserId = user.Id,
                Text = text,
                CreatedAt = DateTime.Now
            };

            _commentService.AddComment(comment);

            return RedirectToAction("Details", "Match", new { id = matchId });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
