using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models
{
    public class Enrollment
    {
        public string IdEnrollment { get; internal set; }
        public string Semestr { get; internal set; }
        public string IdStudy { get; internal set; }
        public string StartDate { get; internal set; }
    }
}
