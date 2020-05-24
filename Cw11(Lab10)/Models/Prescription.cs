using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw11_Lab10_.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public virtual ICollection<Prescription_Medicament> PrescriptionsMedicaments { get; set; }
        [ForeignKey("doctor")]
        public int? IdDoctor { get; set; }
        public Doctor doctor { get; set; }
        [ForeignKey("patient")]
        public int? IdPatient { get; set; }
        public Patient patient { get; set; }
    }
}