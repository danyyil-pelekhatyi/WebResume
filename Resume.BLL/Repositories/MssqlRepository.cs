using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resume.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        ICollection<T> Find(string search, string filter);
    }

    //class MssqlRepository
    //{
    //}
}
