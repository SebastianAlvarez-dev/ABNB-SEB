using Application.Departamentos.Queries;
using Domain;
using Infrastructure.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
