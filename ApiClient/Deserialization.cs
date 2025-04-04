using System.Text.Json;
using ApiClient.AppFlowyException;
using ApiClient.Models;

namespace ApiClient;

public class Deserialization
{
    public async Task<T> Deserialize<T>(HttpResponseMessage response)
    {
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsByteArrayAsync();
                var DTO = JsonSerializer.Deserialize<ResponseObject<T>>(result);
                if (DTO.code == 0)
                {
                    if (DTO.data is not null)
                    {
                        return DTO.data;
                    }

                    throw new NullObjectException("Null response");
                }

                throw new ServerErrorException($"Error {DTO.code} from server: {DTO.message}");
            }

            throw new HttpRequestException(
                $"Response status code does not indicate success: {(int)response.StatusCode}.");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
    }
}