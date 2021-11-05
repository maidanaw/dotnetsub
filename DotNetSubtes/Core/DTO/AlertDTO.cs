using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AlertDTO
    {
        public string AlertCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ActiveStart { get; set; }
        public string ActiveEnd { get; set; }
        public string Cause { get; set; }
        public string Effect { get; set; }
    }
}
