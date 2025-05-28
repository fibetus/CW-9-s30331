using System.ComponentModel.DataAnnotations;

namespace APBD_CW9.DTOs;

public class PatientPrescriptionGetDto
{
    public int? IdPatient { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateOnly Birthdate { get; set; }
}