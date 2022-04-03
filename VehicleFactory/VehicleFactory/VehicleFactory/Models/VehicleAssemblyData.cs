using System.Collections.Generic;
using VehicleFactory.Enums;
using VehicleFactory.Helpers;

namespace VehicleFactory.Models
{
    public class VehicleAssemblyData
    {
        public ProductionStatus Status { get; set; }
        public VehicleModel Vehicle { get; set; }
        public List<EventLog> VehicleAssemblyLogs { get; set; }


        public void SetNextStatus()
        {
            Status = ProductionStatusHelper.MoveNext(Status);
        }
    }
}
