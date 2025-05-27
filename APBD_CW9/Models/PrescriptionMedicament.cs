using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW9.Models;

[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))]
    public virtual Medicament Medicament { get; set; }

    
    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))]
    public virtual Prescription Prescription { get; set; }
        
    public int? Dose { get; set; } 

    [Required]
    [MaxLength(50)]
    public string Details { get; set; }
}