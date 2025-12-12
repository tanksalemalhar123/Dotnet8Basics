namespace PlugAndPlay.Api.Models;

public class ManagerResult<T>
{
    public bool IsSuccess { get; set; }
    public ResponseCode Code { get; set; } = ResponseCode.SUCCESS;
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }

    public ManagerResult() { }

    public ManagerResult(T? data, bool isSuccess, string? message = null, ResponseCode code = ResponseCode.SUCCESS)
    {
        Data = data;
        IsSuccess = isSuccess;
        ErrorMessage = message;
        Code = code;
    }

    // Convenience factory methods (optional)
    public static ManagerResult<T> Success(T? data, string? message = "OK")
        => new ManagerResult<T>(data, true, message, ResponseCode.SUCCESS);

    public static ManagerResult<T> Failure(string? errorMessage, ResponseCode code = ResponseCode.INTERNAL_ERROR)
        => new ManagerResult<T>(default, false, errorMessage, code);
}
