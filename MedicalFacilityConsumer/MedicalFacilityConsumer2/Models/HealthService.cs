using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer.Models
{
    public class HealthService
    {
        public long Id { get; set; }
        public string ServiceName { get; set; }
        public string Specialisation { get; set; }

        public HealthService()
        {

        }

        public HealthService(long id, string name, string specialisation)
        {
            Id = id;
            ServiceName = name;
            Specialisation = specialisation;
        }
    }
}
