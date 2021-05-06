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

        public double GetPatientsDetailsBasedOnLocation(DateTime startDate, DateTime endDate)
        {
            double local = GetLocalPatientCount(startDate, endDate);
            double outstation = GetOutsidePatientCount(startDate, endDate);

            double totalpatient = local + outstation;
            double localpercentage = (local / totalpatient * 100);
            double finalpercentage = (double)Math.Round(localpercentage * 100) / 100;
            return finalpercentage;
        }

        int GetLocalPatientCount(DateTime startDate, DateTime endDate)
        {
            ValidateDates(startDate, endDate);
            List<Patient> listOfLocalPatients = patients.Where(p => p.GetLocation().Equals(this.location))
                                                        .Where(p => p.GetDate() > startDate && p.GetDate() < endDate)
                                                        .ToList();

            return listOfLocalPatients.Count();
        }

        int GetOutsidePatientCount(DateTime startDate, DateTime endDate)
        {
            return patients.Count() - GetLocalPatientCount(startDate, endDate);
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