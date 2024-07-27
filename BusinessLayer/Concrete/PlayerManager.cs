using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PlayerManager : IPlayerService
    {
        private readonly IPlayerDal _playerDal;

        public PlayerManager(IPlayerDal playerDal)
        {
            _playerDal = playerDal;
        }
        public void TAdd(Player player)
        {
            _playerDal.Insert(player);
        }

        public void TDelete(Player player)
        {
            _playerDal.Delete(player);
        }

        public void TUpdate(Player player)
        {
            _playerDal.Update(player);
        }

        public List<Player> TGetList()
        {
            return _playerDal.GetList();
        }

        public Player GetByID(int id)
        {
            return _playerDal.Get(p => p.PlayerId == id);
        }
    }
}
