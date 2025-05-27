using APBD_CW9.Exceptions;
using APBD_CW9.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW9.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController(IDbService service) : ControllerBase
{
    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientDetailsAsync(int idPatient)
    {
        try
        {
            var patientDetails = await service.GetPatientDetailsAsync(idPatient);
            return Ok(patientDetails);
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