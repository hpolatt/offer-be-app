using System;
using Microsoft.AspNetCore.Builder;

namespace QuotationSystem.Application.Exceptions;

public static class ConfigureExceptionMiddleware
{
    public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }

}
