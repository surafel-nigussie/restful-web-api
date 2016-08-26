using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IGenericRepository<T>
        where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        System.Linq.IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        System.Linq.IQueryable<T> GetAll();
        System.Linq.IQueryable<T> GetAll(int start, int count);
        void Save();
    }
}
