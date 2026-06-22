using Domain;
using Microsoft.EntityFrameworkCore;
namespace Infraestructure.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    public DbSet<Departamento> Departamentos { get; set; }
}