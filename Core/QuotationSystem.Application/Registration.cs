using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using System.Globalization;
using QuotationSystem.Application.Exceptions;
using MediatR;
using QuotationSystem.Application.Beheviors;

namespace QuotationSystem.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}