using BookHouse.Model;
using BookHouse.Repository.Abstract;
using BookHouse.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookHouse API", Version = "v1" });
});

// База данных
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? "Host=postgres;Database=bookhouse;Username=postgres;Password=postgres";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Регистрация сервисов
builder.Services.AddControllers();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Включаем Swagger ВСЕГДА, без условий
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookHouse API v1");
    c.RoutePrefix = "swagger"; // Доступ по /swagger
});

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "BookHouse API is running!");

try
{
    app.Logger.LogInformation("Application starting...");
    await app.RunAsync();
}
catch (Exception ex)
{
    app.Logger.LogCritical(ex, "Application startup failed");
    throw;
}