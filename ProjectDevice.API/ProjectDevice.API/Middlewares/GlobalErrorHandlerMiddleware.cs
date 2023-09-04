using ProjectDevice.API.Middlewares.Exceptions;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ProjectDevice.API.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlerMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
 
        }

        private  static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string stackTrace = String.Empty;
            string message;
            var exceptionType = ex.GetType();


            if(exceptionType == typeof(DBConcurrencyException))
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = ex.StackTrace;
            }
            else if(exceptionType == typeof(EntityNotFoundException))
            {
                message = ex.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
            }
            else
            {
                message = ex.Message;
                status = HttpStatusCode.InternalServerError;
                stackTrace = ex.StackTrace;
                throw ex;
            }

            var response = JsonSerializer.Serialize(new { message, status, stackTrace });
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)status;
           
            return context.Response.WriteAsync(response);

        }
    }
}
