using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    public class Hospital_Implementation: IHospital
    {
        private string name;
        private string location;
        private List<Patients> patients = new List<Patients>();

        public Hospital_Implementation(string name, string locatn)
        {
            this.name = name;
            this.location = locatn;
        }
        public string GetName()
        {
            return name;
        }

        public string GetLocation()
        {
            return location;
        }

        public void Addpatients(Patients p) => this.patients.Add(p);

        public double GetLocationpercentcentage(DateTime d1, DateTime d2)
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


            List<Patients> listOfPatients = (List<Patients>)patients.Where(p => p.GetLocation().Equals(this.location)).ToList();
            return GetDateDetails(d1, d2, listOfPatients);


        }

        int GetoutsidePatient(DateTime d1, DateTime d2)
        {
            int Count = 0;
            List<Patients> listOfPatients = (List<Patients>)patients.Where(p => !p.GetLocation().Equals(this.location)).ToList();
            Count = Count + GetDateDetails(d1, d2, listOfPatients);
            return Count;

        }

        int GetDateDetails(DateTime d1, DateTime d2, List<Patients> listOfPatients)
        {
            DateValidation(d1, d2);
            if (listOfPatients != null)
            {
                List<Patients> finalpatnt = (List<Patients>)listOfPatients.Where(p => p.GetDate().CompareTo(d1) > 0 && p.GetDate().CompareTo(d2) < 0).ToList();
                return finalpatnt.Count();
            }
            return 0;
        }

        private static void DateValidation(DateTime startdate, DateTime end)
        {
            if (startdate.CompareTo(end) > 0)
            {
                throw new ArgumentException("Invalid date");
            }
        }
    }
}

