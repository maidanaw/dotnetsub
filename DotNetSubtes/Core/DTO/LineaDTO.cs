using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class LineaDTO
    {
        public string LineaCode { get; set; }
        public List<EstacionDTO> Estaciones { get; set; }
    }

    public class EstacionDTO
    {
        public string StopName { get; set; }
        public ArrivalDTO Arrival { get; set; }
        public DepartureDTO Departure { get; set; }
    }

    public class DepartureDTO
    {
        public string DepartureTime { get; set; }
        public string Delay { get; set; }
    }

    public class ArrivalDTO
    {
        public string ArrivalTime { get; set; }
        public string Delay { get; set; }
    }
}
