using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment1
{
    public class Program    {

        //static Implementation hospital;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Patients p1 = new Patients();
            Patients p2 = new Patients();
            p1.Patient("name", "bangalore", 11, new DateTime(2021, 05, 04));
            p2.Patient("name2", "bangalore", 21, new DateTime(2021, 05, 02));
            

            Implementation hospital = new Implementation("","bangalore");
            hospital.addpatients(p1);
            hospital.addpatients(p2);

            
            double expPercentage = 50;

            double actual = hospital.getLocationpercent(new DateTime(2021, 03, 02), new DateTime(2021, 05, 04));

            Console.WriteLine("Patient of patients : " + actual, true);
            Assert.AreEqual(expPercentage, actual,"Mismatch with data");

        }
        
    }

    
}
