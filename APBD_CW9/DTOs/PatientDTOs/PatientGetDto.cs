using System.ComponentModel.DataAnnotations;
using APBD_CW9.DTOs.PrescriptionDTOs;

namespace APBD_CW9.DTOs;

public class PatientGetDto
{
    [Required]
    public int IdPatient { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateOnly Birthdate { get; set; }
    
    public List<PrescriptionGetDto> Prescriptions { get; set; } = new List<PrescriptionGetDto>();
}