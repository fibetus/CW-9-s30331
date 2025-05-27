using System.ComponentModel.DataAnnotations;
using APBD_CW9.DTOs.DoctorDTOs;
using APBD_CW9.DTOs.MedicamentDTOs;

namespace APBD_CW9.DTOs.PrescriptionDTOs;

public class PrescriptionCreateDto
{
    [Required]
    public PatientPrescriptionGetDto Patient { get; set; }

    [Required]
    public DoctorGetDto Doctor { get; set; } 

    [Required]
    public List<MedicamentPrescriptionCreateDto> Medicaments { get; set; } = new List<MedicamentPrescriptionCreateDto>();

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }
}