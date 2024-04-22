using System.Linq.Expressions;

namespace FrameWork.Domain
{
    public interface IRepository<TKey , T> where T : class
    {
        void Create(T entity);
        T GetBy(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
        void Save();
    }
}
