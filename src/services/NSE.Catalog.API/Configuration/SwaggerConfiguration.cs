using Microsoft.OpenApi.Models;

namespace NSE.Catalog.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Nerdstore Enterprise catálogo API",
                    Description = "Esta API faz parte do curso ASP.NET core enterprise application",
                    Contact = new OpenApiContact() { Name = "Marcilia da Silva", Email = "guilgerm@gmail.com" }

                });
            });
        }

        public static void UseSwaggerConfiguration (this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

    }
}
