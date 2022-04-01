using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory.Enums
{
    public enum ProdctionStatus
    {
        Unknown = 0,
        ScheduledForProduction = 1,
        InProduction = 2,
        Produced = 3,
        Shipped = 4
    }
}
