using APBD_CW9.DTOs.DoctorDTOs;
using APBD_CW9.DTOs.MedicamentDTOs;

namespace APBD_CW9.DTOs.PrescriptionDTOs;

public class PrescriptionGetDto
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public List<MedicamentPrescriptionGetDto> Medicaments { get; set; } = new List<MedicamentPrescriptionGetDto>();
    public DoctorPrescriptionGetDto Doctor { get; set; }
}