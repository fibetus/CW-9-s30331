using APBD_CW9.DTOs.DoctorDTOs;
using APBD_CW9.DTOs.MedicamentDTOs;

namespace APBD_CW9.DTOs.PrescriptionDTOs;

public class PrescriptionGetDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentPrescriptionGetDto> Medicaments { get; set; } = new List<MedicamentPrescriptionGetDto>();
    public DoctorPrescriptionGetDto Doctor { get; set; }
}