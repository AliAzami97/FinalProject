using FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrameWork.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey,T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
