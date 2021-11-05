using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.DTO.ForecastDTO;

namespace Domain.Service
{
    public class ForcastService : CommonService
    {
        private IEnumerable<LineaDTO> PrepareForecast(Forecast ForecastGTFS)
        {
            List<LineaDTO> ForecastsLineas = new List<LineaDTO>();
            LineaDTO LineaForecast;

            foreach (var entity in ForecastGTFS.Entity)
            {
                LineaForecast = new LineaDTO();
                LineaForecast.LineaCode = entity.ID;
                LineaForecast.Estaciones = new List<EstacionDTO>();
                foreach (var estaciones in entity.Linea.Estaciones)
                {
                    LineaForecast.Estaciones.Add(new EstacionDTO()
                    {
                        StopName = estaciones.stop_name,
                        Arrival = new ArrivalDTO() { ArrivalTime = UnixTimeStampToDateTime((double)estaciones.arrival.time).ToString("H:mm"), Delay = TimeSpan.FromSeconds(estaciones.arrival.delay).ToString() },
                        Departure = new DepartureDTO() { DepartureTime = UnixTimeStampToDateTime((double)estaciones.departure.time).ToString("H:mm"), Delay = TimeSpan.FromSeconds(estaciones.departure.delay).ToString() }
                    });
                }
                ForecastsLineas.Add(LineaForecast);
            }
            return ForecastsLineas;
        }

        public IEnumerable<LineaDTO> GetForecastByLineas(Forecast ForecastGTFS)
        {
            return PrepareForecast(ForecastGTFS);
        }
    }
}
