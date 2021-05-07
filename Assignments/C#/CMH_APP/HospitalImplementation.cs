using System;
using System.Collections.Generic;
using System.Linq;

namespace CMH_APP
{
    public class HospitalImplementation : IHospital
    {
        private string name;
        private Location location;
        private List<Patient> patients;

        public HospitalImplementation(string name, Location location)
        {
            this.name = name;
            this.location = location;
            patients = new List<Patient>();
        }

        public string GetName()
        {
            return name;
        }

        public Location GetLocation()
        {
            return location;
        }
        public void AddPatient(Patient p) => this.patients.Add(p);


        public List<Patient> PatientsWithinTheDateRange(DateTime startDate, DateTime endDate)
        {
            ValidateDates(startDate, endDate);
            List<Patient> PatientsWithinTheDateRange = patients.Where(p => p.GetvisitingInfo()
                                                               .Any(x => x.GetVisitDate() >= startDate && x.GetVisitDate() <= endDate))
                                                               .ToList();
            return PatientsWithinTheDateRange;

        }

        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate.CompareTo(endDate) > 0)
            {
                throw new Exception("Invalid date");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chinmaya Mission Hospital");
        }
    }
}