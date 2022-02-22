using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TesodevMicroservices.Core.ServiceResponse;

namespace TesodevMicroservices.OrderService.Application.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, System.Exception ex)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";
            ServiceResponse<object> responseObject = new() { IsSuccess = false, Message = "Unexpected Error Occured.", Data = new { ExceptionMessage = ex.Message } };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(responseObject));
        }
    }
}