using OnlineStore.app.Interfaces.Repositories;
using OnlineStore.app.Interfaces.UnitOfWorks;
using OnlineStore.domain.Entities;
using OnlineStore.Persistence.Context;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineStore.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<User>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();
            
        }
    }
} 
