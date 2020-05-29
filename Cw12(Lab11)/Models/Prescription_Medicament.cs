

namespace Cw12_Lab11_.Models
{
    public class Prescription_Medicament
    {
        public int? IdMedicament { get; set; }
        public Medicament medicament { get; set; }
        public int? IdPrescription { get; set; }
        public Prescription prescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}