﻿using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Data;
using NSE.WebApi.Core.Identidade;

namespace NSE.Catalog.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("Total", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Total");
            app.UseHttpsRedirection();
            app.UseAuthConfiguration();
            app.MapControllers();
        }
    }
}
