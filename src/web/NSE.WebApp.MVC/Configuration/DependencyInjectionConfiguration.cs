using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            services.AddHttpClient<ICatalogoService, CatalogoService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }

    }
}
