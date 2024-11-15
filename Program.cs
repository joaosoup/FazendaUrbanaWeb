using TesteHortoInova.Models;
using Microsoft.EntityFrameworkCore;
using TesteHortoInova.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container
AddServices(builder);

// Configura o pipeline de requisições HTTP
var app = builder.Build();

// Configuração de middleware
ConfigureApp(app);

// Inicializa o aplicativo
app.Run();

// Métodos de configuração separados para melhor organização

// Adiciona os serviços necessários
void AddServices(WebApplicationBuilder builder)
{
    // Adiciona o serviço de Controllers e Views
    builder.Services.AddControllersWithViews();

    // Configura o contexto do banco de dados
    builder.Services.AddDbContext<EstoqueContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Registra o serviço de autenticação
    builder.Services.AddScoped<AuthService>();

    // Configura CORS
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

// Configuração do middleware
void ConfigureApp(WebApplication app)
{
    // Configura o tratamento de exceções e HSTS para ambientes não de desenvolvimento
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    // Habilita o uso de arquivos estáticos
    //app.UseStaticFiles();

    // Configura o roteamento
    app.UseRouting();
    app.UseStaticFiles();


    // Habilita o CORS com a política definida
    app.UseCors("MyPolicy");

    ///app.Use(async (context, next) =>
    //{
    //    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    //   await next.Invoke();
    ///});


    // Configura a rota padrão para iniciar na tela de login
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Inicial}/{action=Index}/{id?}");
}
