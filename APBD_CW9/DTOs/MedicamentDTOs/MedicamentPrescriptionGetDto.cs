using System.ComponentModel.DataAnnotations;

namespace APBD_CW9.DTOs.MedicamentDTOs;

public class MedicamentPrescriptionGetDto
{
    [Required]
    public int IdMedicament { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
}