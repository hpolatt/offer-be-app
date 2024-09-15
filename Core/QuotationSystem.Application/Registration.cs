using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuotationSystem.Application.Exceptions;

namespace QuotationSystem.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
}