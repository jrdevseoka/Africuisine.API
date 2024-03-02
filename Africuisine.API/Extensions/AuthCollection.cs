using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Africuisine.API.Extensions
{
    public static class AuthCollection
    {
        public static IServiceCollection AddAPIAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication((options) =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            return services;
        }
        public static IServiceCollection AddAPIJWTBearer(this IServiceCollection services)
        {
            return services;
        }
    }
}