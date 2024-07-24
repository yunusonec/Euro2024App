using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTeamDal : GenericRepository<Team>, ITeamDal
    {
        private readonly Context _context;

        public EfTeamDal(Context context) 
        {
            _context = context;
        }

        public new List<Team> GetList()
        {
            return _context.Teams
                .Include(t => t.Players) // Players ile ilişkili verileri dahil edin
                .Include(t => t.Coach)   // Coach ile ilişkili verileri dahil edin
                .ToList();
        }

        public Team Get(Func<Team, bool> filter)
        {
            return _context.Teams
                .Include(t => t.Players)
                .Include(t => t.Coach)
                .FirstOrDefault(filter);
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _context.Players.Where(p => p.TeamId == teamId).ToList();
        }

        public Coach GetCoachByTeamId(int teamId)
        {
            // Bu sorgu, 'Team' ilişkisini içeren 'Coach' nesnesini getirir.
            return _context.Coaches
                .Include(c => c.Team) // Eğer 'Team' ile ilgili ek veriler gerekiyorsa
                .FirstOrDefault(c => c.Team.TeamId == teamId);
        }
    }
}

