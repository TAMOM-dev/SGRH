using Microsoft.EntityFrameworkCore;
using SGRH.Application.Contracts.Services;
using SGRH.Application.Services.Servicio;
using SGRH.Infrastructure.Repositories;
using SGRH.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios y repositorios
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();

// Configuración general
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
