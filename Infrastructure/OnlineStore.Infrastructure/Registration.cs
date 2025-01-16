using OnlineStore.app.Interfaces.RedisCache;
using OnlineStore.app.Interfaces.Token;
using OnlineStore.Infrastructure.RedisCache;
using OnlineStore.Infrastructure.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace OnlineStore.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //It maps the JWT section from the appsettings.Local.json file to the TokenSettings class.
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));

            services.AddTransient<ITokenService, TokenService>();

            services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));
            services.AddTransient<IRedisCacheService, RedisCacheService>();

            services.AddAuthentication(option => 
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddStackExchangeRedisCache(rds =>
            {
                rds.Configuration = configuration["RedisCacheSettings:ConnectionString"];
                rds.InstanceName = configuration["RedisCacheSettings:InstanceName"];
            });
        }
    }
}
