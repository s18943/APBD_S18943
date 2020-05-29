using System;
using System.Collections.Generic;

namespace Cw12_Lab11_.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirdthDate { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}