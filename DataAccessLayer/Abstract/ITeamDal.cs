using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITeamDal : IGenericDal<Team>
    {
        Team Get(Func<Team, bool> filter);
        List<Player> GetPlayersByTeamId(int teamId);
        Coach GetCoachByTeamId(int teamId);
        List<Team> GetList();
        List<Coach> GetAllCoaches();
    }
}
