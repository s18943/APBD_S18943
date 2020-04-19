using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; internal set; }
        public int IdEnrollment { get; internal set; }
        public string Studies { get; internal set; }
        public string Semester { get; internal set; }

        public override string ToString()
        {
            return IndexNumber + " " + FirstName + " " + LastName + " " + BirthDate + "\n";
        }
    }
}
