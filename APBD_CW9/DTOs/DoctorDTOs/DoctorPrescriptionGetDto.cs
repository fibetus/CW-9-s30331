using System.ComponentModel.DataAnnotations;

namespace APBD_CW9.DTOs.DoctorDTOs;

public class DoctorPrescriptionGetDto
{
    [Required]
    public int IdDoctor { get; set; }
    
    [Required]
    public string? FirstName { get; set; }
}