using System;
using System.Collections.Generic;

namespace CMH_APP
{
    public interface IHospital
    {
        public void AddPatient(Patient p);
        List<Patient> PatientsWithinTheDateRange(DateTime startDate, DateTime endDate);
    }

}
