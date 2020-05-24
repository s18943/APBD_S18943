using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cw11_Lab10_.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirdthDate { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}