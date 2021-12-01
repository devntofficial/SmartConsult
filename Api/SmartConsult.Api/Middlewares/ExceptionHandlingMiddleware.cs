using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SmartConsult.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;//
                var response = new
                {
                    Message = "An error occured. Please contact admin."
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            
        }
    }
}
