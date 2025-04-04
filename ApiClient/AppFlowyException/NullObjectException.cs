namespace ApiClient.AppFlowyException;

public class NullObjectException : ArgumentNullException
{
    public NullObjectException(string message) : base(message)
    {
    }

    public NullObjectException(string message, Exception innerException) : base(message, innerException)
    {
    }
}