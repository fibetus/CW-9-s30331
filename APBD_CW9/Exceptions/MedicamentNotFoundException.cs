namespace APBD_CW9.Exceptions;

public class MedicamentNotFoundException : Exception
{
    public MedicamentNotFoundException(string? message) : base(message)
    {
    }
}