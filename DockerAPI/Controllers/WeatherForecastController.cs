using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmEarlyBound;
using DockerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;

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
        private readonly ICRMService _crmService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IConfiguration configuration, ICRMService crmService)
        {
            _logger = logger;
            _configuration = configuration;            
            _crmService = crmService;            
        }

        [HttpGet]
        [Route("weatherforecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("TEST LOG");
            _logger.LogWarning("WARNING LOG");            

            //Account Early Bound Entity
            var ac = new Account();
            ac.EMailAddress1 = "bla bla bla";
            //Organization Service
            var orgDetail = _crmService._instance.OrganizationDetail;


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
