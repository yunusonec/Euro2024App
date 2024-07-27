using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMatchService : IGenericService<Match>
    {
        Match GetByID(int id);
        void TAdd(Match t);
        void TDelete(Match t);
        List<Match> TGetList();
        List<Match> TGetLastThreeMatches();
        void TUpdate(Match t);
        IQueryable<Match> GetMatchQueryable();
    }
}
