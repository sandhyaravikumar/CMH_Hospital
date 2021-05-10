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


            Visit Patient1Visit = new Visit(DateTime.Today.AddDays(-1), "Doctor1");
            Visit Patient2Visit = new Visit(DateTime.Today, "Doctor2");

            Patient patient1 = new Patient("BangalorePatient1", Location.Bangalore, 15);
            hospital.AddPatient(patient1);
            patient1.AddVisit(Patient1Visit);

            Patient patient2 = new Patient("BangalorePatient2", Location.Bangalore, 22);
            hospital.AddPatient(patient2);
            patient2.AddVisit(Patient2Visit);

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

            Visit Patient1Visit = new Visit(DateTime.Today.AddDays(-1), "Doctor1");
            Visit Patient2Visit = new Visit(DateTime.Today, "Doctor2");

            Patient patient1 = new Patient("ChennaiPatient", Location.Chennai, 11);
            hospital.AddPatient(patient1);
            patient1.AddVisit(Patient1Visit);

            Patient patient2 = new Patient("PunePatient", Location.Pune, 11);
            hospital.AddPatient(patient2);
            patient2.AddVisit(Patient2Visit);

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

            Visit Patient1Visit = new Visit(DateTime.Today, "Doctor1") ;
            Visit Patient2Visit = new Visit(DateTime.Today.AddDays(-1), "Doctor2") ;
            Visit Patient3Visit = new Visit(DateTime.Today.AddDays(-2), "Doctor3") ;

            Patient patient1 = new Patient("ChennaiPatient", Location.Chennai, 11);
            hospital.AddPatient(patient1);
            patient1.AddVisit(Patient1Visit);

            Patient patient2 = new Patient("PunePatient", Location.Pune, 11);
            hospital.AddPatient(patient2);
            patient2.AddVisit(Patient2Visit);

            Patient patient3 = new Patient("BangalorePatient", Location.Bangalore, 11);
            hospital.AddPatient(patient3);
            patient3.AddVisit(Patient3Visit);

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

            Visit Patient1Visit1 = new Visit(DateTime.Today, "Doctor1");
            Visit Patient1Visit2 = new Visit(DateTime.Today, "Doctor1");
            Visit Patient1Visit3 = new Visit(DateTime.Today.AddDays(-1), "Doctor1");
            Visit Patient2Visit1 = new Visit(DateTime.Today.AddDays(-2), "Doctor2");
            Visit Patient2Visit2 = new Visit(DateTime.Today.AddDays(-1), "Doctor2");

            Patient patient1 = new Patient("PatientBangalore1", Location.Bangalore, 11);
            hospital.AddPatient(patient1);
            patient1.AddVisit(Patient1Visit1);
            patient1.AddVisit(Patient1Visit2);
            patient1.AddVisit(Patient1Visit3);


            Patient patient2 = new Patient("PatientBangalore2", Location.Bangalore, 21);
            hospital.AddPatient(patient2);
            patient2.AddVisit(Patient2Visit1);
            patient2.AddVisit(Patient2Visit2);

            long localPatient = hospital.GetLocalPatientsCount(FromDate, ToDate);

            long expectedLocalPatientCount = 2;

            Console.WriteLine($"Number of Local patients from {FromDate.ToString("MM/dd/yyyy")} to {ToDate.ToString("MM/dd/yyyy")} are {localPatient}");
            Assert.AreEqual(expectedLocalPatientCount, localPatient, "Mismatch with patients data, Please check the data again");
        }

        [TestMethod()]
        public void PatientsWithinTheDateRange()
        {
            int numberOfDays = 3;

            Visit Patient1Visit1 = new Visit(DateTime.Today, "Doctor1");
            Visit Patient1Visit2 = new Visit(DateTime.Today.AddDays(-1), "Doctor1");

            Visit Patient2Visit1 = new Visit(DateTime.Today.AddDays(-2), "Doctor2");
            Visit Patient2Visit2 = new Visit(DateTime.Today.AddDays(-1), "Doctor2");

            Visit Patient3Visit = new Visit(DateTime.Today, "Doctor3");

            Visit Patient4Visit =  new Visit(DateTime.Today, "Doctor4");

            Patient patient1 = new Patient("ChennaiPatient1", Location.Chennai, 11);
            hospital.AddPatient(patient1);
            patient1.AddVisit(Patient1Visit1);
            patient1.AddVisit(Patient1Visit2);

            Patient patient2 = new Patient("BangalorePatient1", Location.Bangalore, 21);
            hospital.AddPatient(patient2);
            patient2.AddVisit(Patient2Visit1);
            patient2.AddVisit(Patient2Visit2);

            Patient patient3 = new Patient("PunePatient1", Location.Pune, 34);
            hospital.AddPatient(patient3);
            patient3.AddVisit(Patient3Visit);


            Patient patient4 = new Patient("BangalorePatient2", Location.Bangalore, 55);
            hospital.AddPatient(patient4);
            patient4.AddVisit(Patient4Visit);

            long localPatientWithinNDays = hospital.PatientsWhoVisitedHospitalInRecentDays(numberOfDays);

            double expectedLocalPatientCount = 2;

            Console.WriteLine($"Number of Local patients for last {numberOfDays} days are {localPatientWithinNDays}");
            Assert.AreEqual(expectedLocalPatientCount, localPatientWithinNDays, "Mismatch with patients data, Please check the data again");
        }

    }
}

