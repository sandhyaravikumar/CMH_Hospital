using CMH_APP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMH_UnitTest
{
    [TestClass]
    public class PatientsTests
    {
        private HospitalImplementation hospital;

        [TestInitialize()]
        public void Initialize()
        {
            List<Patient> Patient = new List<Patient>();
            List<Visit> Visit = new List<Visit>();
            hospital = new HospitalImplementation("CMH", Location.Bangalore);
        }

        [TestMethod()]
        public void Local_Patients_Test()
        {
            DateTime FromDate = new DateTime(2021, 05, 02);
            DateTime ToDate = new DateTime(2021, 05, 05);

            var Patient1visitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 02), "Doctor1") };
            var Patient2VisitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 03), "Doctor2") };


            Patient patient1 = new Patient("BBB", Location.Bangalore, 11, Patient1visitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("BBB", Location.Bangalore, 11, Patient2VisitList);
            hospital.AddPatient(patient2);

            List<Patient> patients = hospital.PatientsWithinTheDateRange(FromDate, ToDate);
            long totalPatients = patients.Count();
            long localPatient = patients.Where(p => p.GetLocation().Equals(hospital.GetLocation())).Count();
            long OutPatients = totalPatients - localPatient;

            double LocalPatientPercentage = (localPatient * 100) / totalPatients;
            double OutsidePatientPercentage = (OutPatients * 100) / totalPatients;
            double expectedPercentage = 100;


            Console.WriteLine($"{LocalPatientPercentage} % of patients are from Local and  No outside patients");
            Assert.AreEqual(expectedPercentage, LocalPatientPercentage, "Mismatch with patients data, Please check the data again");

        }

        [TestMethod()]
        public void Outstation_Patients_Test()
        {
            DateTime FromDate = new DateTime(2021, 05, 02);
            DateTime ToDate = new DateTime(2021, 05, 05);

            var Patient1visitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 02), "Doctor1") };
            var Patient2VisitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 03), "Doctor2") };


            Patient patient1 = new Patient("BBB", Location.Chennai, 11, Patient1visitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("BBB", Location.Pune, 11, Patient2VisitList);
            hospital.AddPatient(patient2);


            List<Patient> patients = hospital.PatientsWithinTheDateRange(FromDate, ToDate);
            long totalPatients = patients.Count();
            long localPatient = patients.Where(p => p.GetLocation().Equals(hospital.GetLocation())).Count();
            long OutPatients = totalPatients - localPatient;


            double LocalPatientPercentage = (localPatient * 100) / totalPatients;
            double OutsidePatientPercentage = (OutPatients * 100) / totalPatients;
            double expectedPercentage = 0;

            Console.WriteLine("No records of Local Patients");
            Assert.AreEqual(expectedPercentage, LocalPatientPercentage, "Mismatch with patients data, Please check the data again");
        }

        [TestMethod()]
        public void All_location_patients_test()
        {
            DateTime FromDate = new DateTime(2021, 05, 02);
            DateTime ToDate = new DateTime(2021, 05, 05);

            var Patient1visitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 02), "Doctor1") };
            var Patient2VisitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 03), "Doctor2") };
            var Patient3visitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 04), "Doctor3") };


            Patient patient1 = new Patient("CCC", Location.Chennai, 11, Patient1visitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("PPP", Location.Pune, 11, Patient2VisitList);
            hospital.AddPatient(patient2);

            Patient patient3 = new Patient("BBB", Location.Bangalore, 11, Patient3visitList);
            hospital.AddPatient(patient3);

            List<Patient> patients = hospital.PatientsWithinTheDateRange(FromDate, ToDate);
            long totalPatients = patients.Count();
            long localPatient = patients.Where(p => p.GetLocation().Equals(hospital.GetLocation())).Count();
            long OutPatients = totalPatients - localPatient;

            double LocalPatientPercentage = (localPatient * 100) / totalPatients;
            double OutsidePatientPercentage = (OutPatients * 100) / totalPatients;
            double expectedPercentage = 33;


            Console.WriteLine($"Number of Local patients from {FromDate.ToString("MM/dd/yyyy")} to {ToDate.ToString("MM/dd/yyyy")} are {localPatient}");
            Assert.AreEqual(expectedPercentage, LocalPatientPercentage, "Mismatch with patients data, Please check the data again");
        }


        [TestMethod()]

        public void PatientWithMultipleVisit()
        {
            DateTime FromDate = new DateTime(2021, 05, 02);
            DateTime ToDate = new DateTime(2021, 05, 05);

            var Patient1VisitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 02), "Doctor1"), new Visit(new DateTime(2021, 05, 03), "Doctor1"), new Visit(new DateTime(2021, 05, 04), "Doctor1") };

            var Patient2VisitList = new List<Visit>() { new Visit(new DateTime(2021, 05, 03), "Doctor2"), new Visit(new DateTime(2021, 05, 02), "Doctor2") };

            Patient patient1 = new Patient("BBB", Location.Bangalore, 11, Patient1VisitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("BBB", Location.Bangalore, 21, Patient2VisitList);
            hospital.AddPatient(patient2);


            List<Patient> patients = hospital.PatientsWithinTheDateRange(FromDate, ToDate);

            long localPatient = patients.Where(p => p.GetLocation().Equals(hospital.GetLocation())).Count();

            long expectedLocalPatientCount = 2;

            Console.WriteLine($"Number of Local patients from {FromDate.ToString("MM/dd/yyyy")} to {ToDate.ToString("MM/dd/yyyy")} are {localPatient}");
            Assert.AreEqual(expectedLocalPatientCount, localPatient, "Mismatch with patients data, Please check the data again");
        }
    }
}

        //[TestMethod()]
        //public void PatientsWithinTheDateRange()
        //{
        //    DateTime FromDate = new DateTime(2021, 05, 02);
        //    DateTime ToDate = new DateTime(2021, 05, 05);



        //    List<Patient> patients = hospital.PatientsWithinTheDateRange(FromDate, ToDate);
        //    long localPatient = patients.Where(p => p.GetLocation().Equals(hospital.GetLocation())).Count();

        //    ////long expectedLocalPatientCount = 3;

        //    //Console.WriteLine($"Number of Local patients from {FromDate.ToString("MM/dd/yyyy")} to {ToDate.ToString("MM/dd/yyyy")} are {localPatient}");
        //    //Assert.AreEqual(expectedLocalPatientCount, localPatient, "Mismatch with patients data, Please check the data again");
        //}

 