using Entities.ErrorModels;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Warehouse.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, Serilog.ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error.",
                        }.ToString());
                    }
                });
            });
        }

    }
}
