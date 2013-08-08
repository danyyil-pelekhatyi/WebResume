using System;
using System.Linq;
using System.Linq.Expressions;

namespace Resume.Core.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
