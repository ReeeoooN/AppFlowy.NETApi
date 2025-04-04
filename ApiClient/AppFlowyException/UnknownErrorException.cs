namespace ApiClient.AppFlowyException;

public class ServerErrorException : Exception
{
    public ServerErrorException(string message) : base(message)
    {
    }

    public ServerErrorException(string message, Exception innerException) : base(message, innerException)
    {
    }
}