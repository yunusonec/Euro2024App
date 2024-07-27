using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Match Match { get; set; }

        public virtual AppUser User { get; set; }
    }
}
