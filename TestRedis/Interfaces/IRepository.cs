using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Text;
using TestRedis.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace TestRedis.Interfaces
{
    public interface IRepository
    {
        IList<Product> GetAll();
        Product Get(Guid id);
        Product Store(Product product);
    }
}
