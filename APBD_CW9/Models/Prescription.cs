using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW9.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public DateOnly DueDate { get; set; }

    [Required]
    public int IdPatient { get; set; }
    [ForeignKey(nameof(IdPatient))]
    public virtual Patient Patient { get; set; }

    [Required]
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))]
    public virtual Doctor Doctor { get; set; }

    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}