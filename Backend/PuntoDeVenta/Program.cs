using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PuntoDeVenta.Services;
using PuntoDeVenta.Middleware;
using PuntoDeVenta.Data;
using PuntoDeVenta.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración de base de datos
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

// Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };
    });

// Servicios
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AuthService>();


// Validaciones
builder.Services.AddControllers().AddFluentValidation(fv =>
    fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .WithOrigins("http://localhost:3000"); // Cambia según la URL de tu frontend
    });
});

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Introduce el token en el formato: Bearer {token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configuración del middleware
app.UseHttpsRedirection();

// CORS
app.UseCors("CorsPolicy");

// Excluir rutas de autenticación (login, register y refresh-token) de la autenticación y autorización
//app.UseWhen(context =>
//    !context.Request.Path.StartsWithSegments("/api/Auth/login", StringComparison.OrdinalIgnoreCase) &&
//    !context.Request.Path.StartsWithSegments("/api/Auth/register", StringComparison.OrdinalIgnoreCase) &&
//    !context.Request.Path.StartsWithSegments("/api/Auth/refresh-token", StringComparison.OrdinalIgnoreCase), builder =>
//    {
//        builder.UseAuthentication();
//        builder.UseAuthorization();
//    });


app.UseAuthentication();
app.UseAuthorization();

// Middleware de permisos personalizado
//app.UseMiddleware<PermissionMiddleware>();

// Rutas de controladores
app.MapControllers();

// Configuración de Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
