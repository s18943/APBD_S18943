using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string BirthDate { get; internal set; }
        public string IdEnrollment { get; internal set; }
        public string Study { get; internal set; }
        public string Semester { get; internal set; }

        public override string ToString()
        {
            return IndexNumber + " " + Imie + " " + Nazwisko + " " + BirthDate + "\n";
        }
    }
}
