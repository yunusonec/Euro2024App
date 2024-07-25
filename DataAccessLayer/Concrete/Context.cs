using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-AN1JPVB\\SQLEXPRESS; database= Euro2024DB ; integrated security = true; ");
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }   
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistics> PlayerStatisticss { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
