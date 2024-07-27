using EntityLayer.Concrete;

namespace Euro2024App.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public virtual Match Match { get; set; }
        public virtual AppUser User { get; set; }
    }
}
