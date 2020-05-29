using System;
using System.Collections.Generic;

namespace Cw12_Lab11_.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public virtual ICollection<Prescription_Medicament> PrescriptionsMedicaments { get; set; }
        public int? IdDoctor { get; set; }
        public Doctor doctor { get; set; }
        public int? IdPatient { get; set; }
        public Patient patient { get; set; }
    }
}