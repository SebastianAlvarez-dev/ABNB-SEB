using Application.Departamentos.Queries;
using Infraestructure.Data;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    if (!dbContext.Departamentos.Any())
    {
        dbContext.Departamentos.AddRange(
            new Domain.Departamento { Nombre = "Departamento 1" },
            new Domain.Departamento { Nombre = "Departamento 2" },
            new Domain.Departamento { Nombre = "Departamento 3" }
        );
        dbContext.SaveChanges();
    }
}

app.MapGet(
    "/departamentos",
    async (IDepartamentoGetAll departamentoGetAll) =>
    {
        var departamentos = await departamentoGetAll.Execute();
        return Results.Ok(departamentos);
    }
);

app.UseHttpsRedirection();

app.Run();
