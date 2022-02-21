using MedicalFacilityConsumer2.Services.Abstrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Services
{
    public class MedicalFacilityFactory
    {
        public IMedicalFacilityService GetMedicalFacilityService(string placowka)
        {
            if (placowka == "Polmed")
            {
                return new PolmedService();
            }
            else if (placowka == "Luxmed")
            {
                return new LuxmedService();
            }
            else if (placowka == "CentrumDamianaService")
            {
                return new CentrumDamianaService();
            }
            throw new ArgumentException("Not handled facility");
        }
    }
}
