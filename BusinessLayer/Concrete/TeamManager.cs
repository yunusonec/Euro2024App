using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public Team GetByID(int id)
        {
            return _teamDal.Get(t => t.TeamId == id);
        }

        public void TAdd(Team t)
        {
            _teamDal.Insert(t);
        }

        public void TDelete(Team t)
        {
            _teamDal.Delete(t);
        }

        public List<Team> TGetList()
        {
            return _teamDal.GetList();
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _teamDal.GetPlayersByTeamId(teamId);
        }

        public Coach GetCoachByTeamId(int teamId)
        {
            return _teamDal.GetCoachByTeamId(teamId);
        }

        public void TUpdate(Team t)
        {
            _teamDal.Update(t);
        }
    }
}
