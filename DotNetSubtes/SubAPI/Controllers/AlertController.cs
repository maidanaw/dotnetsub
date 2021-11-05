using Core.DTO;
using Core.Interfaces;
using Core.UnitOfWork;
using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SubAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private IConfiguration config;
        private readonly AlertService alertService;
        private readonly IUnitOfWork unitOfWork;
        public AlertController(IConfiguration configuration, IUnitOfWork Uow)
        {
            config = configuration;
            alertService = new AlertService(Uow);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetAlertStatus()
        {
            try
            {
                string urlTansporte = config.GetValue<string>("ApiTransporte");
                ServiceAlertDTO result;

                //llamar a la API de subtes
                using (HttpClient client = new HttpClient())
                {                    
                    HttpResponseMessage response = await client.GetAsync($"{urlTansporte}serviceAlerts?json=1&client_id=1&client_secret=1");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                        result = JsonSerializer.Deserialize<ServiceAlertDTO>(content);

                        var data = alertService.PersistAndGetActivesAlerts(result).ToArray();

                        return Ok(data);
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

        [HttpGet("historic")]
        public async Task<IActionResult> GetAlertHistoric()
        {
            try
            {
                return Ok(alertService.GetAllAlerts());
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
