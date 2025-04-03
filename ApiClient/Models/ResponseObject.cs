namespace ApiClient.Models;

public class ResponseObject <T>
{
    public T? data { get; set; }
    public int code { get; set; }
    public string message { get; set; }
}