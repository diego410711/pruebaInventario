using InventarioPrueba.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Habilitar OpenAPI (Swagger)

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Habilitar OpenAPI solo en desarrollo
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
