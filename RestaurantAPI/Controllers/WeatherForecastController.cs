using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForcastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForcastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(
            [FromQuery] int mumberOfResults, 
            [FromQuery] int min, 
            [FromQuery] int max)
        {
            var result = _service.Get();
            return result;
        }

        [HttpGet("currentDay/{max}")]
        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get();
            return result;
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            return StatusCode(401, $"Hello {name}");
        }

        [HttpPost("generate")]

        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int number, [FromBody] object minmax)
        {
            return StatusCode(401, $"{number}");
        }

    }
}