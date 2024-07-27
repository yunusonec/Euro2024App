﻿using DataAccessLayer.Abstract;
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
    public class EfPlayerDal : GenericRepository<Player>, IPlayerDal
    {
        public EfPlayerDal(Context context) : base(context)
        {
        }
        public Player Get(Func<Player, bool> filter)
        {
            return _context.Set<Player>().FirstOrDefault(filter);
        }
    }
}
