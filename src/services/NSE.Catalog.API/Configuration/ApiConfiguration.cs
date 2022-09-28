using NSE.Catalog.API.Data;
using NSE.Catalog.API.Data.Repository;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }

    }
}
