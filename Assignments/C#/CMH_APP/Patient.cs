using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    public enum Location { Bangalore, Chennai, Pune }
    public class Patient
    {
        private string name;
        private Location location;
        private int age;
        private DateTime date;

        public void patient(string name, Location location, int age, DateTime date)
        {
            this.name = name;
            this.location = location;
            this.age = age;
            this.date = date;
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

        public DateTime GetDate()
        {
            return date;
        }


    }


}
