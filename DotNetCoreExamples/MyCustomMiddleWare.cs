using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DotNetCoreExamples
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyCustomMiddleWare(RequestDelegate next, ILoggerFactory ilogger)
        {
            _next = next;
            _logger = ilogger.CreateLogger("MyMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleWare>();
        }
    }
}
