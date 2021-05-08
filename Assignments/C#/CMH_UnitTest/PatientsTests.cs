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
        public void LocalPatientsTest()
        {
            DateTime FromDate = DateTime.Today.AddDays(-1);
            DateTime ToDate = DateTime.Today;

            var Patient1VisitList = new List<Visit>() { new Visit(DateTime.Today.AddDays(-1), "Doctor1") };
            var Patient2VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor2") };

            Patient patient1 = new Patient("BangalorePatient1", Location.Bangalore, 15, Patient1VisitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("BangalorePatient2", Location.Bangalore, 22, Patient2VisitList);
            hospital.AddPatient(patient2);

            long totalPatients = hospital.PatientsWithinTheDateRange(FromDate, ToDate).Count();
            long localPatient = hospital.GetLocalPatientsCount(FromDate, ToDate);

            double LocalPatientPercentage = (localPatient * 100) / totalPatients;
            double expectedPercentage = 100;

            Console.WriteLine($"{LocalPatientPercentage} % of patients are from Local and  No outside patients");
            Assert.AreEqual(expectedPercentage, LocalPatientPercentage, "Mismatch with patients data, Please check the data again");

        }

        [TestMethod()]
        public void OutstationPatientsTest()
        {
            DateTime FromDate = DateTime.Today.AddDays(-1);
            DateTime ToDate = DateTime.Today;

            var Patient1VisitList = new List<Visit>() { new Visit(DateTime.Today.AddDays(-1), "Doctor1") };
            var Patient2VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor2") };

            Patient patient1 = new Patient("ChennaiPatient", Location.Chennai, 11, Patient1VisitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("PunePatient", Location.Pune, 11, Patient2VisitList);
            hospital.AddPatient(patient2);

            long totalPatients = hospital.PatientsWithinTheDateRange(FromDate, ToDate).Count();
            long localPatient = hospital.GetLocalPatientsCount(FromDate, ToDate);

            double LocalPatientPercentage = (localPatient * 100) / totalPatients;
            double expectedPercentage = 0;

            Console.WriteLine("No records of Local Patients");
            Assert.AreEqual(expectedPercentage, LocalPatientPercentage, "Mismatch with patients data, Please check the data again");
        }

        [TestMethod()]
        public void AllLocationPatientsTest()
        {
            DateTime FromDate = DateTime.Today.AddDays(-2);
            DateTime ToDate = DateTime.Today;

            var Patient1VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor1") };
            var Patient2VisitList = new List<Visit>() { new Visit(DateTime.Today.AddDays(-1), "Doctor2") };
            var Patient3VisitList = new List<Visit>() { new Visit(DateTime.Today.AddDays(-2), "Doctor3") };

            Patient patient1 = new Patient("ChennaiPatient", Location.Chennai, 11, Patient1VisitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("PunePatient", Location.Pune, 11, Patient2VisitList);
            hospital.AddPatient(patient2);

            Patient patient3 = new Patient("BangalorePatient", Location.Bangalore, 11, Patient3VisitList);
            hospital.AddPatient(patient3);

            long totalPatients = hospital.PatientsWithinTheDateRange(FromDate, ToDate).Count();
            long localPatient = hospital.GetLocalPatientsCount(FromDate, ToDate);
            long OutPatients = hospital.GetOutsidePatientsCount(FromDate, ToDate);

            double LocalPatientPercentage = (localPatient * 100) / totalPatients;
            double OutsidePatientPercentage = (OutPatients * 100) / totalPatients;
            double expectedPercentage = 33;


            Console.WriteLine($"Date: {FromDate.ToString("MM/dd/yyyy")} to {ToDate.ToString("MM/dd/yyyy")}\n Local Patients: {localPatient}% \n Outpatients: {OutsidePatientPercentage} %");
            Assert.AreEqual(expectedPercentage, LocalPatientPercentage, "Mismatch with patients data, Please check the data again");
        }


        [TestMethod()]

        public void PatientWithMultipleVisit()
        {
            DateTime FromDate = DateTime.Today.AddDays(-2);
            DateTime ToDate = DateTime.Today;

            var Patient1VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor1"), new Visit(DateTime.Today, "Doctor1"), new Visit(DateTime.Today.AddDays(-1), "Doctor1") };

            var Patient2VisitList = new List<Visit>() { new Visit(DateTime.Today.AddDays(-2), "Doctor2"), new Visit(DateTime.Today.AddDays(-1), "Doctor2") };

            Patient patient1 = new Patient("PatientBangalore1", Location.Bangalore, 11, Patient1VisitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("PatientBangalore2", Location.Bangalore, 21, Patient2VisitList);
            hospital.AddPatient(patient2);

            long localPatient = hospital.GetLocalPatientsCount(FromDate, ToDate);

            long expectedLocalPatientCount = 2;

            Console.WriteLine($"Number of Local patients from {FromDate.ToString("MM/dd/yyyy")} to {ToDate.ToString("MM/dd/yyyy")} are {localPatient}");
            Assert.AreEqual(expectedLocalPatientCount, localPatient, "Mismatch with patients data, Please check the data again");
        }

        [TestMethod()]
        public void PatientsWithinTheDateRange()
        {
            int numberOfDays = 3;

            var Patient1VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor1"), new Visit(DateTime.Today, "Doctor1"), new Visit(DateTime.Today.AddDays(-1), "Doctor1") };

            var Patient2VisitList = new List<Visit>() { new Visit(DateTime.Today.AddDays(-2), "Doctor2"), new Visit(DateTime.Today.AddDays(-1), "Doctor2") };

            var Patient3VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor3")};

            var Patient4VisitList = new List<Visit>() { new Visit(DateTime.Today, "Doctor4")};

            Patient patient1 = new Patient("ChennaiPatient1", Location.Chennai, 11, Patient1VisitList);
            hospital.AddPatient(patient1);

            Patient patient2 = new Patient("BangalorePatient1", Location.Bangalore, 21, Patient2VisitList);
            hospital.AddPatient(patient2);

            Patient patient3 = new Patient("PunePatient1", Location.Pune, 34, Patient3VisitList);
            hospital.AddPatient(patient3);

            Patient patient4 = new Patient("BangalorePatient2", Location.Bangalore, 55, Patient4VisitList);
            hospital.AddPatient(patient4);

            long localPatientWithinNDays = hospital.PatientsWhoVisitedHospitalInRecentDays(numberOfDays);

            double expectedLocalPatientCount = 2;

            Console.WriteLine($"Number of Local patients for last {numberOfDays} days are {localPatientWithinNDays}");
            Assert.AreEqual(expectedLocalPatientCount, localPatientWithinNDays, "Mismatch with patients data, Please check the data again");
        }

    }
}

