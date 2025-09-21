using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using perla_metro_stations_service_api.src.Data;

Env.Load();
var builder = WebApplication.CreateBuilder(args);
var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var connectionString = $"Server={host};Port={port};Database={dbName};User={user};Password={password};";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 4, 32))));

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
