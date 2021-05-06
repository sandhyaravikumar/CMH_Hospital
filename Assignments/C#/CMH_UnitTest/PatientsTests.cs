using CMH_APP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CMH_UnitTest
{
    [TestClass]
    public class PatientsTests
    {
        HospitalImplementation hospital;

        [TestInitialize()]

        public void Initialize()
        {
            List<Patient> patients = new List<Patient>();
            hospital = new HospitalImplementation("CMH", Location.Bangalore, patients);
            hospital = new HospitalImplementation("CMH", Location.Bangalore, patients);
        }


            [TestMethod()]

            public void Local_Patients_Test()
            {
                //Initialize();
                Patient patient1 = new Patient();
                Patient patient2 = new Patient();
                patient1.patient("ABC", Location.Bangalore, 11, new DateTime(2021, 05, 04));
                patient2.patient("DEF", Location.Bangalore, 21, new DateTime(2021, 05, 04));

                hospital.AddPatient(patient1);
                hospital.AddPatient(patient2);


                double expectedPercentage = 100;

                double actualpercentage = hospital.GetLocationPercentage(new DateTime(2021, 05, 02), new DateTime(2021, 05, 05));

                Console.WriteLine(actualpercentage + "% of patients are from Bangalore and  No outside patients");
                Assert.AreEqual(expectedPercentage, actualpercentage, "Mismatch with patients data, Please check the data again");

            }

            [TestMethod()]
            public void Outstation_Patients_Test()
            {
                //Initialize();
                Patient patient1 = new Patient();
                Patient patient2 = new Patient();
                patient1.patient("GHI", Location.Chennai, 11, new DateTime(2021, 05, 04));
                patient2.patient("JKL", Location.Pune, 21, new DateTime(2021, 05, 04));

                hospital.AddPatient(patient1);
                hospital.AddPatient(patient2);


                double expectedPercentage = 0;

                double actualpercentage = hospital.GetLocationPercentage(new DateTime(2021, 05, 02), new DateTime(2021, 05, 05));

                Console.WriteLine("No records of Local Patients");
                Assert.AreEqual(expectedPercentage, actualpercentage, "Mismatch with patients data, Please check the data again");


            }

            [TestMethod()]
            public void All_location_patients_test()
            {
                //Initialize();
                Patient patient1 = new Patient();
                Patient patient2 = new Patient();
                Patient patient3 = new Patient();
                patient1.patient("MNO", Location.Chennai, 11, new DateTime(2021, 05, 04));
                patient2.patient("PQR", Location.Pune, 21, new DateTime(2021, 05, 04));
                patient3.patient("STU", Location.Bangalore, 21, new DateTime(2021, 05, 04));

                hospital.AddPatient(patient1);
                hospital.AddPatient(patient2);
                hospital.AddPatient(patient3);


                double expectedPercentage = 33.33;

                double actualpercentage = hospital.GetLocationPercentage(new DateTime(2021, 05, 02), new DateTime(2021, 05, 05));
                double outsidePatientPercentage = 100 - actualpercentage;

                String date = string.Format("Today's date {0} - ", DateTime.Now.ToString("MM/dd/yyyy"));



                Console.WriteLine($"{date} \n Local Patient: {actualpercentage}% \n Outside Patient: {outsidePatientPercentage}%");
                Assert.AreEqual(expectedPercentage, actualpercentage, "Mismatch with patients data, Please check the data again");

            }
        }
    }
