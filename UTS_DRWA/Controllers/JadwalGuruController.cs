using Microsoft.AspNetCore.Mvc;

namespace UTS_DRWA.Controllers;

[ApiController]
[Route("[controller]")]
public class JadwalGuruController : ControllerBase
{
   [HttpGet(Name = "Get Jadwal Guru")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            //Date = DateTime.Now.AddDays(index),
            //TemperatureC = Random.Shared.Next(-20, 55),
            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
