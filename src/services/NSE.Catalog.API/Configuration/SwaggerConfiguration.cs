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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
                {
                    Description = "Insira o token JWT desta maneira Bearer {token}",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
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
