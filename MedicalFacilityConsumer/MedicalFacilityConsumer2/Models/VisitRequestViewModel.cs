using MedicalFacilityConsumer.Helpers;
using MedicalFacilityConsumer2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer.Models
{
    public class VisitRequestViewModel
    {
        [Required]
        public string MedicalFacility { get; set; }
        public List<SelectListItem> AvailableFacilities
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem("Polmed", "Polmed"),
                    new SelectListItem("Luxmed", "Luxmed")
                };
            }
        }

        [Required]
        public long ServiceId { get; set; }
        public List<SelectListItem> AvailableHealthServices
        {
            get
            {
                return HealthServiceHelper.HealthServices
                    .Select(x => new SelectListItem(x.ServiceName, x.Id.ToString()))
                    .ToList();

            }
        }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public string Doctor { get; set; }

        public List<TermModel> Terms { get; set; }
    }
}
