using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH_APP
{
    public class Visit
    {
        private DateTime visitDate;
        private string visitingDoctorName;

        public Visit(DateTime visitDate, string visitingDoctorName)
        {
            this.visitDate = visitDate;
            this.visitingDoctorName = visitingDoctorName;
        }

        public DateTime GetVisitDate()
        {
            return visitDate;
        }

        public string GetVisitingDoctorName()
        {
            return visitingDoctorName;
        }


    }
}
