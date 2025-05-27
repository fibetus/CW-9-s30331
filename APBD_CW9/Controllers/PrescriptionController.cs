using APBD_CW9.DTOs;
using APBD_CW9.DTOs.PrescriptionDTOs;
using APBD_CW9.Exceptions;
using APBD_CW9.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW9.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IDbService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDto prescriptionCreateDto)
    {
        try
        {
            var createdPrescription = await service.AddPrescriptionAsync(prescriptionCreateDto);

            return Created($"/prescriptions/{createdPrescription.IdPrescription}", createdPrescription);
        }
        catch (InvalidDateException ex)
        {
            return Conflict(ex.Message);
        }
        catch (MedicamentsLimitException ex)
        {
            return Conflict(ex.Message);
        }
        catch (MedicamentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DoctorNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (PatientNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}