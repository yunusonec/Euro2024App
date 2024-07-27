using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMatchDal : IGenericDal<Match>
    {
        IQueryable<Match> GetAll(); // IQueryable döndürmeli
        IQueryable<Match> GetMatchQueryable();
        IQueryable<Match> GetLastThreeMatches();
        IQueryable<Match> GetAllQueryable();
        Match GetByID(int id);
    }
}
