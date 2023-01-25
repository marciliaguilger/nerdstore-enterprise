using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();


app.UseApiConfiguration();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Catalogo}/{action=Index}");
});

app.Run();
