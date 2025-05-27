namespace APBD_CW9.Exceptions;

public class MedicamentsLimitException : Exception
{
    public MedicamentsLimitException(string? message) : base(message)
    {
    }
}