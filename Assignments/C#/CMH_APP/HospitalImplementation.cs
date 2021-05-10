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


        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate.CompareTo(endDate) > 0)
            {
                throw new Exception("Invalid date");
            }
        }

        public int PatientsWhoVisitedHospitalInRecentDays(int numberOfDays)
        {
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-numberOfDays);
            return GetLocalPatientsCount(startDate, endDate);
        }

        public int GetLocalPatientsCount(DateTime startDate, DateTime endDate)
        {
            List<Patient> listOfLocalPatients = patients.Where(p => p.GetLocation().Equals(this.location))
                                                        .ToList();

            List<Patient> finalListOfLocalPatients = listOfLocalPatients.Where(p => p.HasPatientVisitedHospitalInNDays(startDate, endDate)).ToList();
            
            return finalListOfLocalPatients.Count();
        }

        public double GetLocalPatientPercentage(DateTime startDate, DateTime endDate)
        {
            long TotalPatientCount = patients.Count();
            long LocalPatientCount = GetLocalPatientsCount(startDate,endDate);

            return (100*LocalPatientCount)/TotalPatientCount;
        }

        public int GetOutsidePatientsCount(DateTime startDate, DateTime endDate)
        {
            return patients.Count() - GetLocalPatientsCount(startDate, endDate);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chinmaya Mission Hospital");
        }
    }
}