using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace QuotationSystem.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
}