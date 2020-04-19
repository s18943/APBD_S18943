using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.DTOs.Responses
{
    public class EnrollStudentResponse
    {
        //public string LastName { get; set; }
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
        public int IdStudy { get; internal set; }
        public int IdEnrollment { get; internal set; }
    }
}
