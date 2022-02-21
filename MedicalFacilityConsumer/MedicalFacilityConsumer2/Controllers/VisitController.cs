using MedicalFacilityConsumer.Helpers;
using MedicalFacilityConsumer.Models;
using MedicalFacilityConsumer2.Models;
using MedicalFacilityConsumer2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer.Controllers
{
    public class VisitController : Controller
    {
        private VisitService visitService;

        public VisitController()
        {
            visitService = new VisitService();
        }

        public IActionResult Index()
        {
            return View(new VisitRequestViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(VisitRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var healthService = HealthServiceHelper.HealthServices.FirstOrDefault(x => x.Id == model.ServiceId);
            if (healthService == null)
            {
                ModelState.AddModelError("ServiceId", "Nieprawidlowa usluga");
                return View(model);
            }

            var request = new VisitTermsRequestModel()
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                ServiceId = model.ServiceId,
                Specialisation = healthService.Specialisation,
                Doctor = model.Doctor
            };

            try
            {
                var terms = await visitService.SearchTerms(model.MedicalFacility, request);
                model.Terms = terms;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
    }
}
