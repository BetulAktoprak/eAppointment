using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAppointmentServer.Application;
public sealed class Result<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("errorMessages")]
    public List<string> ErrorMessages { get; set; } = new();
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
        ErrorMessages = new() { errorMessage };
    }

    public Result(int statusCode, List<string> errorMessages)
    {
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
        IsSuccessful = false;
    }

    public static Result<T> Succeed(T data)
    {
        return new(data);
    }

    public static Result<T> Failure(int statusCode, string errorMessage, T data)
    {
        return new(statusCode, new List<string> { errorMessage });
    }
    public static Result<T> Failure(int statusCode, string errorMessage)
    {
        return new(statusCode, errorMessage);
    }

    public static Result<T> Failure(string errorMessage)
    {
        return new(500, errorMessage);
    }

    public static Result<T> Failure(List<string> errorMessages)
    {
        return new(500, errorMessages);
    }
    public static Result<T> Failure(List<string> errorMessages, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        return new(statusCode, errorMessages);
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}
