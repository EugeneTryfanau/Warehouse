using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll(string includeProperties = "");
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, string includeProperties = "");
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
