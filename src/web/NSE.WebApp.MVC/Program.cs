using Microsoft.AspNetCore.Localization;
using NSE.WebApp.MVC.Configuration;
using NSE.WebApp.MVC.Extensions;
using System.Globalization;
using System.Runtime.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();

app.UseRouting();
app.UseIdentityConfiguration();

app.UseApiConfiguration();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Catalogo}/{action=Index}");
});
var supportedCultures = new[] { new CultureInfo("pt-Br") };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
