using Africuisine.Domain.Entities.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddUserContext(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddSQLContext(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddRecipeContext(this IServiceCollection services)
        {
            return services;
        }
    }
}
