using System;
using System.Collections.Generic;

namespace CMH_APP
{
    public enum Location { Bangalore, Chennai, Pune }
    public class Patient
    {
        private string name;
        private Location location;
        private int age;
        private List<Visit> visit;

        public Patient(string name, Location location, int age)
        {
            this.name = name;
            this.location = location;
            this.age = age;
            visit = new List<Visit>();
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
            return visit;
        }

        public void AddVisit(Visit v)
        {
            visit.Add(v);
        }
    }

}
