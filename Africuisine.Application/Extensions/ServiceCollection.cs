using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Africuisine.Application.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection ExtendApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
