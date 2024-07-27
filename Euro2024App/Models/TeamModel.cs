using System.ComponentModel.DataAnnotations;

namespace Euro2024App.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Takım adı gereklidir.")]
        public string Name { get; set; }
        public string PhotoUrl { get; set; }

        [Required(ErrorMessage = "Koç ID'si gereklidir.")]
        public int CoachId { get; set; }
    }
}
