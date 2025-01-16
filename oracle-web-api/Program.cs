using Microsoft.EntityFrameworkCore;
using oracle_web_api.Context;
using oracle_web_api.Interfaces;
using oracle_web_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios e interfaces
builder.Services.AddScoped<IAttentionService, AttentionService>();

// Siempre debe estar antes del build
var connectionString = builder.Configuration.GetConnectionString("Produccion");
builder.Services.AddDbContext<ModelContext>(x =>
    x.UseOracle(
    connectionString
    //options => options.UseOracleSQLCompatibility(19)

    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
