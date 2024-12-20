using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAppointmentServer.Application;
public sealed class Result<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    //[JsonPropertyName("errorMessages")]
    // public List<string> ErrorMessages { get; set; }
    [JsonPropertyName("isSuccessful")]
    public bool IsSuccessful { get; set; } = true;

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

    [JsonConstructor]
    public Result()
    {

    }
    public Result(T data)
    {
        Data = data;
    }

    public Result(int statusCode, string errorMessage)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        //ErrorMessages = new() { errorMessage };
    }
    public static implicit operator Result<T>(T data)
    {
        return new(data);
    }
    public static Result<T> Succeed(T data)
    {
        return new(data);
    }
    public static Result<T> Failure(string errorMessage)
    {
        return new(500, errorMessage);
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}
