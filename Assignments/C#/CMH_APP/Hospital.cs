using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    public interface IHospital
    {
        public void AddPatient(Patient p);
        double GetPatientsDetailsBasedOnLocation(DateTime startDate, DateTime endDate);
    }

}
