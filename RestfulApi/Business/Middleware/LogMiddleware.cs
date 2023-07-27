using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestfulApi.Business.Middleware
{
    public class LogMiddleware
    {

        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<LogMiddleware> _logger;


        public LogMiddleware(RequestDelegate requestDelegate, ILogger<LogMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context) {


            string requestInfo = $"{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ss.fffZ} | {context.Request.Method} {context.Request.Path}";
            _logger.LogInformation("Incoming Request: {RequestInfo}", requestInfo);

            await _requestDelegate(context);

            string responseInfo = $"{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ss.fffZ} | Status Code: {context.Response.StatusCode}";
            _logger.LogInformation("Outgoing Response: {ResponseInfo}", responseInfo);


        }
    }
}
