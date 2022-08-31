using Microsoft.OpenApi.Models;

namespace NSE.Identity.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Nerdstore Enterprise Identity API",
                Description = "API construida como parte do curso ASP.NET Core Enterprise Applications",
                Contact = new OpenApiContact() { Name = "Marcilia da Silva", Email = "guilgerm@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licences/MIT") }
            }));
        }
    }
}
