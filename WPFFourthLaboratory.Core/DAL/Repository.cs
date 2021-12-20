using System.Data.Entity;
using System.Linq;
using WPFFourthLaboratory.DAL.Interfaces;
using WPFFourthLaboratory.DAL.Models.Entities.Base;

namespace WPFFourthLaboratory.DAL.DAL
{
    public abstract class Repository<T> : IRepository<T>
    where T : Entity
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        protected Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public virtual IQueryable<T> Read()
        {
            return _dbSet.AsQueryable();
        }

        public virtual T Create(T obj)
        {
            var existedObj = _dbSet.FirstOrDefault(x => x.Id == obj.Id);

            if (existedObj != null)
                return null;

            _dbSet.Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public virtual T Update(T obj)
        {
            var existedObj = _dbSet.FirstOrDefault(x => x.Id == obj.Id);

            if (existedObj == null)
                return null;

            _context.Entry(existedObj).State = EntityState.Modified;
            _context.Entry(existedObj).CurrentValues.SetValues(obj);
            _context.SaveChanges();

            return obj;
        }

        public virtual bool Delete(T obj)
        {
            var existedObj = _dbSet.FirstOrDefault(x => x.Id == obj.Id);

            if (existedObj == null)
                return false;

            _context.Entry(existedObj).State = EntityState.Deleted;
            _dbSet.Remove(existedObj);
            _context.SaveChanges();

            return true;
        }
    }
}