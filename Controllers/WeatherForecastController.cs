using LionDev.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LionDev.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private ApplicationDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("Get")]        
        public dynamic Get()
        {        
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity, _context);

            if(!rToken.success) return rToken;

            //Usuario usuario = rToken.result;
            Usuario comprador = rToken.result;

            //if (usuario.rol != "administrador")
            if (comprador.Rol != "Administrador")
                {
                return new
                {
                    success = false,
                    message = "No tienes permiso para ver el forecast"
                };
            }

            //return "response": "Weather forecast data from the backend";
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
                /*,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]*/
            })
            .ToArray();
        }
    }
}