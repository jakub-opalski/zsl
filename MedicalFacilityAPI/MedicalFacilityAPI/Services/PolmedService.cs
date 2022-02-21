using MedicalFacilityAPI.Helpers;
using MedicalFacilityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalFacilityAPI.Services
{
    public class PolmedService
    {
        public static List<string> AvailableSpecialisations
            = new List<string>
            {
                "internista", "psychiatria"
            };

        public static Dictionary<string, List<TermModel>> AvailableTerms
            = new Dictionary<string, List<TermModel>>();

        public PolmedService()
        {
            LoadTerms();
        }

        public List<TermModel> SearchTerms(DateTime dateFrom, DateTime dateTo, string specialisation, string doctor = null)
        {
            //Random exception to see if it will be handled appropriatly on client side
            if (DateTime.Now.Second < 5)
            {
                throw new InvalidOperationException("Not handled exception");
            }

            if (!AvailableSpecialisations.Contains(specialisation))
            {
                throw new ArgumentException("Placówka nie obsługuje wybranej usługi");
            }

            var results = AvailableTerms[specialisation].Where(x => x.TermDate >= dateFrom && x.TermDate <= dateTo);
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

            foreach (var serviceId in AvailableSpecialisations)
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
