using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DockerAPI.Controllers
{
    [ApiController]    
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("weatherforecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("config")]
        public string GetConfig()
        {
            //Devuelvo un valor alojado en Azure App Configuration
            var azureConfigValue = _configuration["TestApp:Settings:Message"];
            return azureConfigValue;
        }

        [HttpGet]
        [Route("keyvault")]
        public string GetKeyVaultSecret()
        {
            //Devuelvo un valor alojado en Azure Key Vault
            var azureConfigValue = _configuration["KeyVaultReferenceTest"];
            return azureConfigValue; 
        }
    }
}
