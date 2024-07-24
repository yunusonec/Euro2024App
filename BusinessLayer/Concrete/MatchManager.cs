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
            throw new NotImplementedException();
        }

        public void TAdd(Match t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Match t)
        {
            throw new NotImplementedException();
        }

        public List<Match> TGetList()
        {
            return _matchDal.GetList();
        }
        public List<Match> TGetLastThreeMatches()
        {
            return _matchDal.GetLastThreeMatches();
        }

        public void TUpdate(Match t)
        {
            throw new NotImplementedException();
        }
    }
}
