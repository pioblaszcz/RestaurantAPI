using RestaurantAPI;
using RestaurantAPI.Entities;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddTransient<IWeatherForcastService, WeatherForcastService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<RestaurantDbContext>();
builder.Services.AddScoped<RestaurantSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();

seeder.Seed();

app.UseHttpsRedirection(); // Zapytanie automatycznie przekierowywane na https

app.MapControllers();

app.Run();
