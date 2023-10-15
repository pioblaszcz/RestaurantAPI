namespace RestaurantAPI;

public interface IWeatherForcastService
{
    IEnumerable<WeatherForecast> Get();
}