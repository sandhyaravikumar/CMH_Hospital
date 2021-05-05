using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment1
{
    public interface IHospital
    {
        public void addpatients(Patients p);
        double getLocationpercent(DateTime d1, DateTime d2);
    }

}
