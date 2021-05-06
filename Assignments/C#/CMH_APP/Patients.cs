using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    public class Patients
    {
        private string name;
        private string location;
        private int age;
        private DateTime date;

        public void Patient(string name, string location, int age, DateTime date)
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

        public string GetLocation()
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
