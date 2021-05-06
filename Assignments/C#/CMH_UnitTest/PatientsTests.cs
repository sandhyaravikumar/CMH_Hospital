using CMH_APP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMH_UnitTest
{
    [TestClass]
    public class PatientsTests
    {
        Hospital_Implementation hospital = new Hospital_Implementation("CMH", "Bangalore");

        [TestMethod()]

        public void Local_Patients_Test()
        {
            Patients patient1 = new Patients();
            Patients patient2 = new Patients();
            patient1.Patient("ABC", "Bangalore", 11, new DateTime(2021, 05, 04));
            patient2.Patient("DEF", "Bangalore", 21, new DateTime(2021, 05, 02));
                       
            hospital.Addpatients(patient1);
            hospital.Addpatients(patient2);


            double expPercentage = 100;

            double actualpercentage = hospital.GetLocationpercentcentage(new DateTime(2021, 03, 02), new DateTime(2021, 05, 07));

            Console.WriteLine(actualpercentage + "% of patients are from Bangalore and  No outside patients");
            Assert.AreEqual(expPercentage, actualpercentage, "Mismatch with data");

        }
        [TestMethod()]
        public void Outstation_Patients_Test()
        {
            Patients patient1 = new Patients();
            Patients patient2 = new Patients();
            patient1.Patient("GHI", "Chennai", 11, new DateTime(2021, 05, 04));
            patient2.Patient("JKL", "Pune", 21, new DateTime(2021, 05, 02));

            hospital.Addpatients(patient1);
            hospital.Addpatients(patient2);


            double expPercentage = 0;

            double actualpercentage = hospital.GetLocationpercentcentage(new DateTime(2021, 03, 01), new DateTime(2021, 05, 06));

            Console.WriteLine("No records of Local Patients");
            Assert.AreEqual(expPercentage, actualpercentage, "Mismatch with data");


        }

        [TestMethod()]
        public void All_location_patients_test()
        {
            Patients patient1 = new Patients();
            Patients patient2 = new Patients();
            Patients patient3 = new Patients();
            patient1.Patient("MNO", "Chennai", 11, new DateTime(2021, 05, 04));
            patient2.Patient("PQR", "Pune", 21, new DateTime(2021, 05, 02));
            patient3.Patient("STU", "Bangalore", 21, new DateTime(2021, 05, 02));

            hospital.Addpatients(patient1);
            hospital.Addpatients(patient2);
            hospital.Addpatients(patient3);


            double expPercentage = 33.33;

            double actualpercentage = hospital.GetLocationpercentcentage(new DateTime(2021, 03, 01), new DateTime(2021, 05, 05));


            Console.WriteLine("For the given time period " + actualpercentage + "% of patients are from Bangalore and  " + (100 - actualpercentage) + "% are from other places");
            Assert.AreEqual(expPercentage, actualpercentage, "Mismatch with data");

        }
    }
}