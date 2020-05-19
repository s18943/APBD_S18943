using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DTOs.Responses
{
    public class PromoteStudentResponse
    {
        private object enr;

        public PromoteStudentResponse(object enr)
        {
            this.enr = enr;
        }

        //public string LastName { get; set; }
        public int Semester { get; set; }
        //public string Studies { get; set; }
        public DateTime StartDate { get; set; }
        public int IdEnrollment { get; internal set; }
        public int IdStudy { get; internal set; }
    }
}
