using EntityLayer.Concrete;

namespace Euro2024App.Models
{
    public class TeamDetailsViewModel
    {
        public Team Team { get; set; }
        public List<Player> Players { get; set; }
        public Coach Coach { get; set; }
}
}
