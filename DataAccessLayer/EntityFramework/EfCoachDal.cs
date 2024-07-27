using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCoachDal : GenericRepository<Coach>, ICoachDal
    {
        public EfCoachDal(Context context) : base(context)
        {
        }
        public List<Coach> GetList()
        {
            return _context.Coaches.ToList();
        }
        public Coach Get(Func<Coach, bool> filter)
        {
            return _context.Coaches.FirstOrDefault(filter);
        }
    }
}
