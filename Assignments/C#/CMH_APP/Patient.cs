using System;
using System.Collections.Generic;
using System.Linq;

namespace CMH_APP
{
    public enum Location { Bangalore, Chennai, Pune }
    public class Patient
    {
        private string name;
        private Location location;
        private int age;
        private List<Visit> VisitList;

        public Patient(string name, Location location, int age)
        {
            this.name = name;
            this.location = location;
            this.age = age;
            VisitList = new List<Visit>();
        }

        public string GetName()
        {
            return name;
        }

        public Location GetLocation()
        {
            return location;
        }

        public int GetAge()
        {
            return age;
        }
        public List<Visit> GetvisitingInfo()
        {
            return VisitList;
        }

        public void AddVisit(Visit v)
        {
            VisitList.Add(v);
        }

        public Boolean HasPatientVisitedHospitalInNDays(DateTime startDate, DateTime endDate)
        {
            return VisitList.Any(v => v.GetVisitDate()>= startDate && v.GetVisitDate() <= endDate) ? true : false;
        } 
    }

}
