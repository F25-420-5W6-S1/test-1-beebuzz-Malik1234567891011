using BeeBuzz.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeeBuzz.Data.Repositories
{
    public class BeeBuzzGenericRepository<T> : IBeeBuzzGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BeeBuzzGenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(object id) => _dbSet.Find(id)!;

        public void SaveAll() => _context.SaveChanges();

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
