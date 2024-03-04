using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Africuisine.Domain.Entities.User;
using Africuisine.Application.Data.Config;
using System.Text;
using Africuisine.Infrastructure.Email;
using Africuisine.Domain.Repositories.Repository;
using Africuisine.Infrastructure.Persistence.Repositories.Users;
using Africuisine.Domain.Repositories.Repository.Ingredients;
using Africuisine.Infrastructure.Persistence.Repositories.Ingredients;
using Africuisine.Domain.Interfaces.Ingredients;
using Africuisine.Domain.Repositories.Services;
using Africuisine.Infrastructure.Services.Files;
using Africuisine.Infrastructure.Services.Log;

namespace Africuisine.Infrastructure.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAPIUserDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<UserDbContext>( opts =>
            {
                
                opts.UseSqlServer(connectionString);
            });
            services.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<UserDbContext>()
                            .AddDefaultTokenProviders();

            return services;
        }
        public static IServiceCollection AddAPIAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var JWT = configuration.GetSection("JWT").Get<JwtConfig>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = false, //Enable to prod
                       ValidAudiences = JWT.ValidAudiences,
                       ValidIssuer = JWT.ValidIssuer,
                       ClockSkew = TimeSpan.Zero,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.Key))
                   };
               });

            return services;
        }
        public static IServiceCollection AddAPIDefaultDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<AfricuisineDbContext>((options) =>
            {
                options.UseSqlServer(connection);
            });
            return services;
        }
        public static IServiceCollection AddRecipeContext(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddAPIInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPostmarkService, PostmarkService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ILog, Log>();
            services.AddScoped<ICulturalGroupRepository, CulturalGroupRepository>();
            services.AddScoped<IIngrCategoryRepository, IngrCategoryRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            return services;
        }
    }
}
