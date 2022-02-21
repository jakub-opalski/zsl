using MedicalFacilityConsumer2.Models;
using MedicalFacilityConsumer2.Services.Abstrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Services
{
    public class CentrumDamianaService : IMedicalFacilityService
    {
        public Task<List<TermModel>> SearchAvailableTerms(VisitTermsRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
