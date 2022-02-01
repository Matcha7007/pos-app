using System;
using System.Net;
using System.Threading.Tasks;
using PosAPI.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PosAPI.Middlewares
{
    public class ExceptionMidlewares
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMidlewares> logger;
        private readonly IHostEnvironment env;

        public ExceptionMidlewares(RequestDelegate next, 
                                    ILogger<ExceptionMidlewares> logger,
                                    IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ApiError response;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                String message;
                var exceptionType = ex.GetType();

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode = HttpStatusCode.Forbidden;
                    message = "You are not authorized";
                } else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Some unknown error occured";
                }

                if (env.IsDevelopment())
                {
                    response = new ApiError((int)statusCode, ex.Message, ex.StackTrace.ToString());
                } else 
                {
                    response = new ApiError((int)statusCode, message);
                }
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}