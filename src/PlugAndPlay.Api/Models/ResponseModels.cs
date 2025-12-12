namespace PlugAndPlay.Api.Models;

public class ResponseModel
{
    public ResponseCode Code { get; set; }
    public string Message { get; set; } = string.Empty;
}

// Generic version used when returning data
public class ResponseModel<T> : ResponseModel
{
    public T? Data { get; set; }
}