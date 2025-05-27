namespace APBD_CW9.DTOs.MedicamentDTOs;

public class MedicamentPrescriptionGetDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}