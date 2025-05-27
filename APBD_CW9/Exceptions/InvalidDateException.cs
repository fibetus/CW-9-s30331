namespace APBD_CW9.Exceptions;

public class InvalidDateException : Exception
{
    public InvalidDateException(string? message) : base(message)
    {
    }
}