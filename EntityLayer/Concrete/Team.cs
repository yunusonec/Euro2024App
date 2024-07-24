using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        
        [ForeignKey("CoachId")]
        public virtual Coach Coach { get; set; }
        public int CoachId { get; set; }
        public virtual ICollection<Player> Players { get; set; }


    }
}
