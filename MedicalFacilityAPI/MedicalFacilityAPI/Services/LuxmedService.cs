using MedicalFacilityAPI.Helpers;
using MedicalFacilityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalFacilityAPI.Services
{
    public class LuxmedService
    {
        public static List<long> AvailableServices
            = new List<long>
            {
                1, 3, 4
            };

        public static Dictionary<long, List<TermModel>> AvailableTerms
            = new Dictionary<long, List<TermModel>>();

        public LuxmedService()
        {
            LoadTerms();
        }

        public List<TermModel> SearchTerms(DateTime dateFrom, DateTime dateTo, long serviceId, string doctor = null)
        {
            if (!AvailableServices.Contains(serviceId))
            {
                throw new ArgumentException("Placówka nie obsługuje wybranej usługi");
            }

            var results = AvailableTerms[serviceId].Where(x => x.TermDate >= dateFrom && x.TermDate <= dateTo);
            if (!string.IsNullOrWhiteSpace(doctor))
            {
                results = results.Where(x => !string.IsNullOrWhiteSpace(x.Doctor) && x.Doctor.ToLower().Contains(doctor.ToLower()));
            }
            return results.ToList();
        }

        private void LoadTerms()
        {
            if (AvailableTerms.Count > 0)
            {
                return;
            }

            var nextDay = DateTime.Now.Date.AddDays(1);

            foreach (var serviceId in AvailableServices)
            {
                var list = new List<TermModel>();
                for (var day = 0; day < 6; day++)
                {
                    for (var hour = 10; hour < 15; hour++)
                    {
                        list.Add(new TermModel(nextDay.AddDays(day).AddHours(hour), NameGenerator.GetRandomName()));
                    }                    
                }
                AvailableTerms.Add(serviceId, list);
            }
        }
    }
}
