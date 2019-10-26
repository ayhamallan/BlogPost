using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repository.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
        IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get();


    }
}
