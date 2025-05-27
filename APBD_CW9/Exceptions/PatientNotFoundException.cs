namespace APBD_CW9.Exceptions;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string? message) : base(message)
    {
    }
}