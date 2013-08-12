using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Resume.Core.Interfaces;

namespace Resume.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ObjectSet<T> ObjectSet;

        public Repository(ObjectContext context)
        {
            ObjectSet = context.CreateObjectSet<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return ObjectSet.Where(predicate);
        }

        public void Add(T item)
        {
            ObjectSet.AddObject(item);
        }

        public void Delete(T item)
        {
            ObjectSet.DeleteObject(item);
        }

        public void Update(T item)
        {
            //**********************
        }
    }
}


