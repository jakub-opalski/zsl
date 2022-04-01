using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFactory.Enums;

namespace VehicleFactory.Models
{
    public class EventLog
    {
        public ProductionLogType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
