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
        ICoachDal _coachDal;

        public CoachManager(ICoachDal coachDal)
        {
            _coachDal = coachDal;
        }

        public Coach GetByID(int id)
        {
            throw new NotImplementedException();
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
            return _coachDal.GetList();
        }

        public void TUpdate(Coach t)
        {
            _coachDal.Update(t);
        }
    }
}
