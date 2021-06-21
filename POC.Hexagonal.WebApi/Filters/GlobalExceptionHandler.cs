using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using POC.Hexagonal.Domain.Exceptions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace POC.Hexagonal.WebApi.Filters
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception == null) return;

            string erro;

            switch (exception)
            {
                case NotificationException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    erro = JsonSerializer.Serialize(ex.Notifications);
                    break;
                case DomainException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    erro = ex.ToString();
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    erro = exception.ToString();
                    break;
            }

            context.Response.ContentType = "application/json; charset=utf-8";

            await context.Response.WriteAsync(erro);

            await this.next(context);
        }
    }
}