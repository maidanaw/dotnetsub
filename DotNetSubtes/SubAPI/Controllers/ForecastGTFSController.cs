using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static Core.DTO.ForecastDTO;

namespace SubAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ForecastGTFSController : ControllerBase
    {
        private IConfiguration config;
        private readonly ForcastService forcastService;
        public ForecastGTFSController(IConfiguration configuration)
        {
            config = configuration;
            forcastService = new ForcastService();
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetSubteForecast()
        {
            try
            {
                string urlTansporte = config.GetValue<string>("ApiTransporte");
                Forecast result;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{urlTansporte}forecastGTFS?client_id=1&client_secret=1");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        result = JsonSerializer.Deserialize<Forecast>(content);
                        var resp = forcastService.GetForecastByLineas(result);
                        return Ok(resp);
                    }
                    else
                    {
                        return StatusCode(500, "Ocurrio un problema! Intente mas tarde.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
