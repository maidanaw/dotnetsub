using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime LastModification { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            LastModification = DateTime.Now;
        }
    }
}
