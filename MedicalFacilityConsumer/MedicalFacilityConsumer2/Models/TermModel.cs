using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Models
{
    public class TermModel
    {
        public Guid SlotId { get; set; }
        public DateTime TermDate { get; set; }
        public string Doctor { get; set; }
        public string AdditionalInfo { get; set; }

    }
}
