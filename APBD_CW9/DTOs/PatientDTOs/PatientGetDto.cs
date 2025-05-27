using APBD_CW9.DTOs.PrescriptionDTOs;

namespace APBD_CW9.DTOs;

public class PatientGetDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public List<PrescriptionGetDto> Prescriptions { get; set; } = new List<PrescriptionGetDto>();
}