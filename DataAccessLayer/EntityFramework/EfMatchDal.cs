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
    public class EfMatchDal : GenericRepository<Match>, IMatchDal
    {
        private readonly Context _context;
        public EfMatchDal(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Match> GetAll()
        {
            return _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam);
        }

        public IQueryable<Match> GetLastThreeMatches()
        {
            return _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .OrderByDescending(m => m.Date)
                .Take(3);
        }

        public Match GetByID(int id)
        {
            return _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .FirstOrDefault(m => m.Id == id);
        }
        public IQueryable<Match> GetAllQueryable()
        {
            return _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Comments)
                    .ThenInclude(c => c.User);
        }
        public IQueryable<Match> GetMatchQueryable()
        {
            return _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Comments)
                    .ThenInclude(c => c.User);
        }
    }
}
