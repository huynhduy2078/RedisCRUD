using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestRedis.Entities;

namespace TestRedis.Middleware
{
    public class ipMiddleware : ControllerBase
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<IpConfig> _ipAccept;

        public string IPAddress { get; private set; }

        public ipMiddleware(RequestDelegate next, IOptions<IpConfig> options)
        {
            _next = next;
            _ipAccept = options;
        }


        public async Task Invoke(HttpContext context)
        {
            string IPAddress = GetIPAddress();

            string[] listIpAccept = _ipAccept.Value.ListIpAccess;

            int pos = Array.IndexOf(listIpAccept, IPAddress);

            if (pos == -1) // does not exist in the list
            {
                context.Response.StatusCode = 401; //Bad Request                
                await context.Response.WriteAsync("Ip not allowed to connect");
                return;
            }

            await _next(context);
        }


        private string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }


    }
}
