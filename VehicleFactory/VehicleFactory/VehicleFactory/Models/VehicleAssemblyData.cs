using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFactory.Enums;

namespace VehicleFactory.Models
{
    public class VehicleAssemblyData
    {
        public ProdctionStatus Status { get; set; }
        public VehicleModel Vehicle { get; set; }
        public List<EventLog> VehicleAssemblyLogs { get; set; }
    }
}
