using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Data;

namespace NSE.Catalog.API.Configuration
{
    public static class DbConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
