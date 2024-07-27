using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly Context _context;  // Protected olarak tanımlanır
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)  // Context parametresi alır
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public List<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.AsEnumerable() : _dbSet.Where(filter).AsEnumerable();
        }
        public IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            return _dbSet.AsNoTracking().Where(filter).ToList();
        }
    }
}
