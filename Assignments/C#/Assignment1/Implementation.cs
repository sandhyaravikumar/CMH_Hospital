using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Assignment1
{
    public class Implementation: IHospital
    {
        private string name;
        private string location;
        private List<Patients> patients = new List<Patients>();

        public Implementation(string name,string locatn)
        {           
            this.name = name;
            this.location = locatn;
        }
        public string getName()
        {
            return name;
        }

        public string getLocation()
        {
            return location;
        }

        public void addpatients(Patients p) => this.patients.Add(p);

        public double getLocationpercent(DateTime d1, DateTime d2)
        {
            double bang = getBangalorePatient(d1, d2);
            double outside = getoutsidePatient(d1, d2);

            double totalpatient = bang + outside;
            double bangPercen = (bang / totalpatient * 100);
            double otherpercent = (double)Math.Round(bangPercen * 100) / 100;
            double outsidePercentage = 100 - bangPercen;
            return otherpercent;
        }

        int getBangalorePatient(DateTime d1, DateTime d2)
        {
            

            List<Patients>listOfPatients = (List<Patients>)patients.Where(p => p.getLocation().Equals(this.location)).ToList();
            return getDateDetails(d1, d2, listOfPatients);

            
        }

        int getoutsidePatient(DateTime d1, DateTime d2)
        {
            int Count = 0;
            List<Patients> listOfPatients = (List<Patients>)patients.Where(p => !p.getLocation().Equals(this.location)).ToList();
            Count = Count + getDateDetails(d1, d2, listOfPatients);
            return Count;

        }

        int getDateDetails(DateTime d1, DateTime d2, List<Patients> listOfPatients)
        {
            dateValidation(d1, d2);
            if (listOfPatients != null)
            {
                List<Patients> finalpatnt = (List<Patients>)listOfPatients.Where(p => p.getDate().CompareTo(d1) > 0 && p.getDate().CompareTo(d2) < 0).ToList();
                return finalpatnt.Count();
            }
            return 0;
        }

        private void dateValidation(DateTime startdate, DateTime end)
        {
            if (startdate.CompareTo(end) > 0)
            {
                throw new ArgumentException("Invalid date");
            }
        }
    }
}
