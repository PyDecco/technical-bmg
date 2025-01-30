using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Repositories;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args);

var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

    var connString = isDevelopment ? builder.Configuration.GetConnectionString("DEV-DOCKER-POSTGRESQL") :
                    builder.Configuration.GetConnectionString("PROD-DOCKER-POSTGRESQL");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connString)); 

builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ClientService>();


builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();

