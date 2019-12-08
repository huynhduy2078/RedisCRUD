using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using TestRedis.Entities;
using TestRedis.Interfaces;

namespace TestRedis.DataEF
{
    public class EFRepository : IRepository
    {
        private readonly IRedisClient _redisClient;

        public EFRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }
        public IList<Product> GetAll()
        {
            var typedClient = _redisClient.As<Product>();
            {
                return typedClient.GetAll();
            }
        }
        public Product Get(Guid id)
        {
            var typedClient = _redisClient.As<Product>();
            {
                return typedClient.GetById(id);
            }
        }

        public Product Store(Product product)
        {
            var typedClient = _redisClient.As<Product>();
            {
                if (product.Id == default(Guid))
                {
                    product.Id = Guid.NewGuid();
                }
                return typedClient.Store(product);
            }
        }
    }
}
