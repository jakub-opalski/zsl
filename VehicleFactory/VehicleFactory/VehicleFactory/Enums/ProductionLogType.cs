using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory.Enums
{
    public enum ProductionLogType
    {
        Unknown = 0,
        ProductionScheduled = 1,
        ProductionStarted = 2,
        ProductionCompleted = 3,
        VehicleShipped = 4,
        DelayInReceivingParts = 5,
        PartsReceived = 6
    }
}
