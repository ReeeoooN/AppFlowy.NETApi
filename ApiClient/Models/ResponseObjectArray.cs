namespace ApiClient.Models;

public class ResponseObjectArray <T> : ResponseObject<T>
{
    public T[]? data { get; set; }

}