using System.ComponentModel.DataAnnotations;

namespace APBD_CW9.DTOs;

public class PatientCreateDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime Birthdate { get; set; }
}