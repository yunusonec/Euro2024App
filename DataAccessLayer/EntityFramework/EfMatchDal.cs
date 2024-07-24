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
        public List<Match> GetLastThreeMatches()
        {
            using var context = new Context();
            return context.Matches
                          .Include(m => m.HomeTeam)
                          .Include(m => m.AwayTeam)
                          .OrderByDescending(m => m.Date)
                          .Take(3)
                          .ToList();
        }
    }
}
