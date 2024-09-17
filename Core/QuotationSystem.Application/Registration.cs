using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using System.Globalization;
using QuotationSystem.Application.Exceptions;
using MediatR;
using QuotationSystem.Application.Beheviors;
using QuotationSystem.Application.Base;

namespace QuotationSystem.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddRulesFromAssembly(assembly, typeof(BaseRules));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));
        }

        private static IServiceCollection AddRulesFromAssembly(this IServiceCollection services, Assembly assembly, Type type)
        {
            var rules = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && !t.IsAbstract && type != t);
            foreach (var rule in rules)
                services.AddTransient(rule);
            
            return services;
        }
        
    }
}