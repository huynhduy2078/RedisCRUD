using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using TestRedis.DataEF;
using TestRedis.Entities;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace TestRedis
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EFRepository _context;

        public ProductController(EFRepository context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.GetAll().AsQueryable();
        }

        public Product Get(Guid id)
        {
            var product = _context.Get(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        public HttpResponseMessage Post([Microsoft.AspNetCore.Mvc.FromBody] Product product)
        {
            var result = _context.Store(product);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(Guid id, [Microsoft.AspNetCore.Mvc.FromBody] Product product)
        {
            var existingEntity = _context.Get(id);
            if (existingEntity == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            product.Id = id;
            _context.Store(product);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
