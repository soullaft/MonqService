using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonqService.Data;

namespace MonqService.Extensions
{
    public static class ApplicationServiceExtenstions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services
            , IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
