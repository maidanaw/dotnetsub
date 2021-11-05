using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Alert : BaseEntity
    {
        public string AlertCode { get; set; }
        public string Header_Text { get; set; }
        public string Description_Text { get; set; }
        public DateTime? ActivePeriodStart { get; set; }
        public DateTime? ActivePeriodEnd { get; set; }
        public DateTime? EndActivePeriodStart { get; set; }
        public DateTime? EndActivePeriodEnd { get; set; }
        public Cause Cause { get; set; }
        public Effect Effect { get; set; }
        public string Language { get; set; }        
    }
}
