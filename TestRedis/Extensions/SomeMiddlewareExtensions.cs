using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRedis.Middleware;

namespace TestRedis.Extensions
{
    public static class SomeMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ipMiddleware>();
        }
    }
}
