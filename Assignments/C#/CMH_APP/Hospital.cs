using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    public interface IHospital
    {
        public void Addpatients(Patients p);
        double GetLocationpercentcentage(DateTime d1, DateTime d2);
    }

}
