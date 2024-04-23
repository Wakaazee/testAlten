using TestAlten.DataAccess.Interfaces;
using TestAlten.DataAccess.Repositories;
using TestAlten.Services.Interfaces;
using TestAlten.Services.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuration de l'application
        ConfigureApp(builder.Services);

        var app = builder.Build();

        // Configurer l'application pour le déploiement
        ConfigureAppForDeployment(app, builder.Configuration);

        app.Run();
    }

    private static void ConfigureApp(IServiceCollection services)
    {
        // Configuration des services
        services.AddControllersWithViews();

        // Récupération du chemin du fichier JSON à partir de appsettings.json
        string jsonFilePath = services.BuildServiceProvider().GetService<IConfiguration>().GetSection("jsonPath").Value;

        // Injection de dépendances avec le chemin du fichier JSON
        services.AddSingleton<IProductRepository, ProductRepository>(provider => new ProductRepository(jsonFilePath));
        services.AddTransient<IProductService, ProductService>();

        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy("AnyOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }

    private static void ConfigureAppForDeployment(WebApplication app, IConfiguration configuration)
    {
        // Configuration du pipeline de requêtes HTTP...
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors("AnyOrigin");

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}