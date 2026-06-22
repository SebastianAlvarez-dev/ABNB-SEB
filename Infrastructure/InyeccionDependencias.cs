using Domain;
using Infraestructure.Data;
using Infraestructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InyecciónDependencias
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        IConfiguration configuration = services
            .BuildServiceProvider()
            .GetRequiredService<IConfiguration>();
        var connectionString = configuration
            .GetConnectionString("abnbdb");
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IDepartamentoRepository , DepartamentoRepository>();
    }
}
