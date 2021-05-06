using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    
    public class HospitalImplementation : IHospital
    {
        private string name;
        private Location location;
        private List<Patient> patient = new List<Patient>();

        public HospitalImplementation(string name, Location location, List<Patient> patient)
        {
            this.name = name;
            this.location = location;
            this.patient = patient;
        }
        public string GetName()
        {
            return name;
        }

        public Location GetLocation()
        {
            return location;
        }


        public void AddPatient(Patient p) => this.patient.Add(p);

        public double GetLocationPercentage(DateTime d1, DateTime d2)
        {
            double local = GetBangalorePatient(d1, d2);
            double outstation = GetoutsidePatient(d1, d2);

            double totalpatient = local + outstation;
            double banglorepercentage = (local / totalpatient * 100);
            double finalpercentage = (double)Math.Round(banglorepercentage * 100) / 100;
            return finalpercentage;
        }

        int GetBangalorePatient(DateTime d1, DateTime d2)
        {
            List<Patient> listOfPatients = (List<Patient>)patient.Where(p => p.GetLocation().Equals(this.location)).ToList();
            return GetDateDetails(d1, d2, listOfPatients);
        }

        int GetoutsidePatient(DateTime d1, DateTime d2)
        {
            int Count = 0;
            List<Patient> listOfPatients = (List<Patient>)patient.Where(p => !p.GetLocation().Equals(this.location)).ToList();
            Count = Count + GetDateDetails(d1, d2, listOfPatients);
            return Count;

        }

        int GetDateDetails(DateTime d1, DateTime d2, List<Patient> listOfPatients)
        {
            DateValidation(d1, d2);
            if (listOfPatients != null)
            {
                List<Patient> finalpatient = (List<Patient>)listOfPatients.Where(p => p.GetDate() > d1 && p.GetDate() < d2).ToList();
                return finalpatient.Count();
            }
            return 0;
        }

        private static void DateValidation(DateTime startdate, DateTime end)
        {
            if (startdate.CompareTo(end) > 0)
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

