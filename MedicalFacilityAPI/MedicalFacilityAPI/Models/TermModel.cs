using System;

namespace MedicalFacilityAPI.Models
{
    public class TermModel
    {
        public Guid SlotId { get; set; }
        public DateTime TermDate { get; set; }
        public string Doctor { get; set; }
        public string AdditionalInfo { get; set; }

        public TermModel(DateTime termDate, string doctor)
        {
            SlotId = Guid.NewGuid();
            TermDate = termDate;
            Doctor = doctor;
        }

        public TermModel(DateTime termDate, string doctor, string additionalInfo)
            : this(termDate, doctor)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}
