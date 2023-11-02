using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawlerExample.DataAccess
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

    }
}

