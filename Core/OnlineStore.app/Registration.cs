using OnlineStore.app.Exceotions;
using OnlineStore.app.Beheviors;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using OnlineStore.app.Features.Products.Rules;
using OnlineStore.app.Bases;

namespace OnlineStore.app
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));

            //ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-TR");

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly ,Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }

            return services;
        }

    }
}
