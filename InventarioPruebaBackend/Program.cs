using InventarioPruebaBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Habilitar OpenAPI (Swagger)

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<JwtService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.Productos.Any())
    {
        context.Productos.AddRange(new List<Producto>
        {
            new Producto { Nombre = "Laptop", Cantidad = 10 },
            new Producto { Nombre = "Mouse", Cantidad = 50 },
            new Producto { Nombre = "Teclado", Cantidad = 30 }
        });
        context.SaveChanges();
    }
}

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Habilitar OpenAPI solo en desarrollo
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
