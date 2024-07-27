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
    public class CoachManager : ICoachService
    {
        private readonly ICoachDal _coachDal;

        public CoachManager(ICoachDal coachDal)
        {
            _coachDal = coachDal;
        }

        public Coach GetByID(int id)
        {
            return _coachDal.Get(c => c.CoachId == id);
        }

        public void TAdd(Coach t)
        {
            _coachDal.Insert(t);
        }

        public void TDelete(Coach t)
        {
            _coachDal.Delete(t);
        }
        public List<Coach> TGetList()
        {
            return _coachDal.GetList(); // Veya uygun bir implementasyon
        }
        public List<Coach> GetAllCoaches()
        {
            return _coachDal.GetList(); // Veya uygun bir şekilde implement edin
        }

        public void TUpdate(Coach t)
        {
            _coachDal.Update(t);
        }
    }
}
