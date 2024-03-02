using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Asp.Versioning;

namespace Africuisine.API.Extensions
{
    public static class SwaggerCollection
    {
        public static IServiceCollection AddAPIVersioning(this IServiceCollection services)
        {
            services.Configure<RouteOptions>((opts) =>{
                opts.LowercaseUrls = true;
            }).AddApiVersioning((opts) => {
                opts.DefaultApiVersion = new ApiVersion(1.0);
            });
            return services;
        }
        public static IServiceCollection AddSwaggerGeneration(this IServiceCollection services)
        {
            services.AddSwaggerGen((opts) =>
            {
                opts.SwaggerDoc("1.0", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "AfriCuisine Api",
                    License = new OpenApiLicense { Name = "MIT" }
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                opts.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
                opts.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });
            return services;
        }
    }
}