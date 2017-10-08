using OAA.Data;
using System.Linq;

namespace OAA.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        IQueryable<T> GetQueryable(long id);
        IQueryable<T> GetQueryable();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
