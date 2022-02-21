using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Models
{
    public class VisitTermsRequestModel
    {
        public long ServiceId { get; set; }
        public string Specialisation { get; set; }
        public string Doctor { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
