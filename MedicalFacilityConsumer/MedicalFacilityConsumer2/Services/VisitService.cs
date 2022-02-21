using MedicalFacilityConsumer2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Services
{
    public class VisitService
    {
        private MedicalFacilityFactory medicalFacilityFactory;
        public VisitService()
        {
            medicalFacilityFactory = new MedicalFacilityFactory();
        }

        public async Task<List<TermModel>> SearchTerms(string placowka, VisitTermsRequestModel request)
        {
            var service = medicalFacilityFactory.GetMedicalFacilityService(placowka);
            return await service.SearchAvailableTerms(request);
        }
    }
}
