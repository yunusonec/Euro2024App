using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MatchManager : IMatchService
    {
        IMatchDal _matchDal;

        public MatchManager(IMatchDal matchDal)
        {
            _matchDal = matchDal;
        }

        public Match GetByID(int id)
        {
            return GetMatchQueryable().FirstOrDefault(m => m.Id == id);
        }

        public void TAdd(Match t)
        {
            _matchDal.Insert(t);
        }

        public void TDelete(Match t)
        {
            _matchDal.Delete(t);
        }

        public List<Match> TGetList()
        {
            return _matchDal.GetAllQueryable().ToList();
        }
        public List<Match> TGetLastThreeMatches()
        {
            return _matchDal.GetAllQueryable()
               .OrderByDescending(m => m.Date)  // Son maçları almak için tarihe göre sırala
               .Take(3)  // İlk 3 maçı al
               .ToList();
        }

        public void TUpdate(Match t)
        {
            _matchDal.Update(t);
        }
        public IQueryable<Match> GetMatchQueryable() // Bu metodu uygulayın
        {
            return _matchDal.GetMatchQueryable();
        }
    }
}
