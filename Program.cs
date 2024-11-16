using TesteHortoInova.Models;
using Microsoft.EntityFrameworkCore;
using TesteHortoInova.Services;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder);

var app = builder.Build();

ConfigureApp(app);

app.Run();

void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<EstoqueContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<AuthService>();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyPolicy", policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        });
    });
}

void ConfigureApp(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseRouting();
    app.UseStaticFiles();


    app.UseCors("MyPolicy");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Inicial}/{action=Index}/{id?}");
}
