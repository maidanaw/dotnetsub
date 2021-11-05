using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ServiceAlertDTO
    {
        public Header header { get; set; }
        public List<Entity> entity { get; set; }
    }

    public class Header
    {
        public string gtfs_realtime_version { get; set; }
        public int incrementality { get; set; }
        public int timestamp { get; set; }
    }

    public class ActivePeriod
    {
        public int? start { get; set; }
        public int? end { get; set; }
    }

    public class InformedEntity
    {
        public string agency_id { get; set; }
        public string route_id { get; set; }
        public int route_type { get; set; }
        public string stop_id { get; set; }
    }

    public class HeaderText
    {
        public string text { get; set; }
        public string language { get; set; }
    }

    public class DescriptionText
    {
        public string text { get; set; }
        public string language { get; set; }
    }

    public class Entity
    {
        public string id { get; set; }
        public List<ActivePeriod> active_period { get; set; }
        public List<InformedEntity> informed_entity { get; set; }
        public int cause { get; set; }
        public int effect { get; set; }
        public List<HeaderText> header_text { get; set; }
        public List<DescriptionText> description_text { get; set; }
    }
}
