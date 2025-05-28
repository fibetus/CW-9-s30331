using System.ComponentModel.DataAnnotations;

namespace APBD_CW9.DTOs.MedicamentDTOs;

public class MedicamentPrescriptionCreateDto
{
    [Required]
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}