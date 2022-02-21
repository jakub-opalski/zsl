using MedicalFacilityConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer.Helpers
{
    public class HealthServiceHelper
    {
        public static List<HealthService> HealthServices
            = new List<HealthService>
            {
                new HealthService(1, "Telekonsultacja - internista", "internista"),
                new HealthService(2, "Telekonsultacja - pediatra", "internista"),
                new HealthService(3, "Telekonsultacja - psychiatra", "psychiatria"),
                new HealthService(4, "Telekonsultacja - dietetyk", "dietetyka"),
                new HealthService(5, "Telekonsultacja - optyk", "optyka"),
            };
    }
}
