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
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = DESKTOP-AN1JPVB\\SQLEXPRESS; database= Euro2024DB ; integrated security = true; ");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasMany(m => m.Comments)
                .WithOne(c => c.Match)
                .HasForeignKey(c => c.MatchId);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }   
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistics> PlayerStatisticss { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
