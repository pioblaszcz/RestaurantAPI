using RestaurantAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IWeatherForcastService, WeatherForcastService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection(); // Zapytanie automatycznie przekierowywane na https

app.MapControllers();

app.Run();
