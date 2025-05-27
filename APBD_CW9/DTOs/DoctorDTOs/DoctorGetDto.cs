using System.ComponentModel.DataAnnotations;

namespace APBD_CW9.DTOs.DoctorDTOs;

public class DoctorGetDto
{
    [Required]
    public int IdDoctor { get; set; }
}