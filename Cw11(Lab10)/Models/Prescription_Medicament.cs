using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw11_Lab10_.Models
{
    public class Prescription_Medicament
    {
        [Key]
        [ForeignKey("medicament")]
        public int? IdMedicament { get; set; }
        public Medicament medicament { get; set; }
        [Key]
        [ForeignKey("prescription")]
        public int? IdPrescription { get; set; }
        public Prescription prescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}