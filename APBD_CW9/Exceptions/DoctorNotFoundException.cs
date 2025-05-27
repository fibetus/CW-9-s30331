namespace APBD_CW9.Exceptions;

public class DoctorNotFoundException : Exception
{
    public DoctorNotFoundException(string? message) : base(message)
    {
    }
}