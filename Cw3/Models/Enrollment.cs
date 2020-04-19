using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models
{
    public class Enrollment
    {
        public int IdEnrollment { get; internal set; }
        public int Semester { get; internal set; }
        public int IdStudy { get; internal set; }
        public DateTime StartDate { get; internal set; }
    }
}
