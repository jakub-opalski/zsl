using MedicalFacilityConsumer2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Services.Abstrat
{
    public interface IMedicalFacilityService
    {
        public Task<List<TermModel>> SearchAvailableTerms(VisitTermsRequestModel request);
    }
}
