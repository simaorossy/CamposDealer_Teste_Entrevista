using CamposDealer.ControleVendas.Db;
using CamposDealer.ControleVendas.Db.Repositories;
using CamposDealer.ControleVendas.Services.Service;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CamposDealerContext>(options =>
         options.UseSqlServer(
             Configuration.GetConnectionString("DefaultConnection"),
             b => b.MigrationsAssembly("CamposDealer.ControleVendas.MVC")
         ));

        services.AddControllersWithViews().AddRazorRuntimeCompilation(); 

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddCors(options =>
        {
            options.AddPolicy("All", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
        });

        services.AddTransient<ClienteRepository>();
        services.AddTransient<ProdutoRepository>();
        services.AddTransient<VendaRepository>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        app.MapControllers();
        app.UseAuthorization();

        app.MapControllerRoute(
        "default",
        "{api}/{controller}/{action}/{id}");
    }
}