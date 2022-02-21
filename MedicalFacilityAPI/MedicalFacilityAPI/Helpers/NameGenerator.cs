using System;
using System.Collections.Generic;

namespace MedicalFacilityAPI.Helpers
{
    public class NameGenerator
    {
        private static Random rand = new Random(DateTime.Now.Millisecond);

        private static List<string> _maleNames = new List<string> { "Jakub", "Tomek", "Karol", "Damian", "Robert", "Grzegorz", "Marcin", "Marek", "Patryk", "Mariusz" };
        private static List<string> _femaleNames = new List<string> { "Anna", "Sabina", "Magda", "Dorota", "Wioletta", "Marzena" };
        private static List<string> _lastNames = new List<string> { "Wiosna", "Marzec", "Jesień", "Zima", "Lato" };

        public static string GetRandomName()
        {
            string firstName;
            if (rand.Next(1, 2) == 1)
            {
                firstName = _maleNames[rand.Next(0, _maleNames.Count - 1)];
            }
            else
            {
                firstName = _femaleNames[rand.Next(0, _femaleNames.Count - 1)];
            }
            var lastName = _lastNames[rand.Next(0, _lastNames.Count - 1)];
            return $"{ firstName } { lastName}";
        }
    }
}
