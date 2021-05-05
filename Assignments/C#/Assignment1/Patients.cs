using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
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

        public string getName()
        {
            return name;
        }

        public string getLocation()
        {
            return location;
        }

        public int getAge()
        {
            return age;
        }

        public DateTime getDate()
        {
            return date;
        }


    }


}
