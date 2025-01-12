using hepsiburada.app.Exceotions;
using hepsiburada.app.Beheviors;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using hepsiburada.app.Features.Products.Rules;
using hepsiburada.app.Bases;

namespace hepsiburada.app
{
    public static class Registration
    {
        public static void AddApp(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddTransient<ExceptionMiddleware>();
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            //ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-TR");

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly ,Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(type);
            }

            return services;
        }

    }
}
