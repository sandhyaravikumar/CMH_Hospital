using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1.Tests


{

    [TestClass()]
    public class PatientsTests
    {
        Implementation hospital = new Implementation("Chinmaya", "bangalore");

        [TestMethod()]

        public void PatientTest()
        {
            Patients p1 = new Patients();
            Patients p2 = new Patients();
            p1.Patient("name", "bangalore", 11, new DateTime(2021, 05, 04));
            p2.Patient("name2", "bangalore", 21, new DateTime(2021, 05, 02));


            hospital.addpatients(p1);
            hospital.addpatients(p2);


            double expPercentage = 100;

            double actual = hospital.getLocationpercent(new DateTime(2021, 03, 02), new DateTime(2021, 05, 04));

            Console.WriteLine(actual + "% of patients are from Bangalore and  No outside patients");
            Assert.AreEqual(expPercentage, actual, "Mismatch with data");

        }
        [TestMethod()]
        public void PatientTest2()
        {
            Patients p1 = new Patients();
            Patients p2 = new Patients();
            p1.Patient("name", "chennai", 11, new DateTime(2021, 05, 04));
            p2.Patient("name2", "pune", 21, new DateTime(2021, 05, 02));

            hospital.addpatients(p1);
            hospital.addpatients(p2);


            double expPercentage = 0;

            double actual = hospital.getLocationpercent(new DateTime(2021, 03, 02), new DateTime(2021, 05, 04));

            Console.WriteLine("No records of Local Patients");
            Assert.AreEqual(expPercentage, actual, "Mismatch with data");

        }

        [TestMethod()]
        public void PatientTest3()
        {
            Patients p1 = new Patients();
            Patients p2 = new Patients();
            Patients p3 = new Patients();
            p1.Patient("name", "bangalore", 11, new DateTime(2021, 05, 03));
            p2.Patient("name4", "bangalore", 43, new DateTime(2021, 05, 03));
            p3.Patient("name2", "pune", 21, new DateTime(2021, 05, 02));

            hospital.addpatients(p1);
            hospital.addpatients(p2);
            hospital.addpatients(p3);


            double expPercentage = 66.67;

            double actual = hospital.getLocationpercent(new DateTime(2021, 03, 02), new DateTime(2021, 05, 04));

            Console.WriteLine("For the given time period " + actual + "% of patients are from Bangalore and  " + (100 - actual) + "% are from other places");
            Assert.AreEqual(expPercentage, actual, "Mismatch with data");

        }
    }
}