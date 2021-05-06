using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CMH_APP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chinmaya Hostpital");
            Patients patient1 = new Patients();
            Patients patient2 = new Patients();
            patient1.Patient("name", "Bangalore", 11, new DateTime(2021, 05, 04));
            patient2.Patient("name2", "Bangalore", 21, new DateTime(2021, 05, 02));


            Hospital_Implementation hospital = new Hospital_Implementation("CMH", "Bangalore");
            hospital.Addpatients(patient1);
            hospital.Addpatients(patient2);


            double expPercentage = 100;

            double actualpercentage = hospital.GetLocationpercentcentage(new DateTime(2021, 03, 02), new DateTime(2021, 05, 04));

            Console.WriteLine(actualpercentage + "% of patients are from Bangalore and  No outside patients");
            Assert.AreEqual(expPercentage, actualpercentage, "Mismatch with data");


        }

    }


}
