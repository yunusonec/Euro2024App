using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PlayerStatistics> PlayerStatistics { get; set; }
    }
}
