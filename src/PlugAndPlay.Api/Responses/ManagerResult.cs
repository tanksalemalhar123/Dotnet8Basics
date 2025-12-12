namespace PlugAndPlay.Api.Responses;

public class ManagerResult<T>
{
    public ManagerResult(T? data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }

    public T? Data { get; }
    public bool Success { get; }
    public string Message { get; }
}
