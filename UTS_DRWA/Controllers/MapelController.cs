using Microsoft.AspNetCore.Mvc;

namespace UTS_DRWA.Controllers;

[ApiController]
[Route("[controller]")]
public class MapelController : ControllerBase
{
   [HttpGet(Name = "Get Mapel")]
    public IEnumerable<WeatherForecast> Get(){
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            //Date = DateTime.Now.AddDays(index),
            //TemperatureC = Random.Shared.Next(-20, 55),
            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("{NIP}")]
    public IEnumerable<WeatherForecast> GetNIP(){
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            //Date = DateTime.Now.AddDays(index),
            //TemperatureC = Random.Shared.Next(-20, 55),
            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost(Name = "Get Mapel")]
    public IEnumerable<WeatherForecast> Post(){
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            //Date = DateTime.Now.AddDays(index),
            //TemperatureC = Random.Shared.Next(-20, 55),
            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}