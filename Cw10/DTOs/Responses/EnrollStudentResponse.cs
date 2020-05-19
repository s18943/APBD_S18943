using Cw10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DTOs.Responses
{
    public class EnrollStudentResponse
    {
        public EnrollStudentResponse(Enrollment enrollment)
        {
            Semester = enrollment.Semester;
            StartDate = enrollment.StartDate;
            IdStudy = enrollment.IdStudy;
            IdEnrollment = enrollment.IdEnrollment;
        }

        //public string LastName { get; set; }
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
        public int IdStudy { get; internal set; }
        public int IdEnrollment { get; internal set; }
    }
}
