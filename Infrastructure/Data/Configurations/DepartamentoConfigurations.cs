using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations;

public class DepartamentoConfigurations : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");
        builder.HasKey(d => d.Id);
        builder
            .Property(d => d.Nombre)
            .HasConversion(n => n.Value, s => new Nombre(s))
            .HasColumnName("NombreDepartamento")
            .HasMaxLength(100)
            .IsRequired();
    }
}
