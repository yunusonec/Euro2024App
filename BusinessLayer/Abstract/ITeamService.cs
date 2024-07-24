using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITeamService : IGenericService<Team>
    {
        List<Player> GetPlayersByTeamId(int teamId);
        Coach GetCoachByTeamId(int teamId);
    }
}
