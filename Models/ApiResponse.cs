namespace Sampas_Mobil_Etkinlik.Models;
public class ApiResponse<T> : ApiResponse
{
    public T Data { get; }

    public ApiResponse(T data) : this(true, string.Empty, data)
    {
    }

    public ApiResponse(string message) : this(false, message, default)
    {
    }

    public ApiResponse(bool success, string message, T data) : base(success, message)
    {
        Data = data;
    }
}

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ICollection<string> Errors { get; }

    public ApiResponse(bool success, string message)
    {
        Success = success;
        Message = message;
        Errors = null;
    }

    public ApiResponse(bool success, string message, ICollection<string> errors = null)
    {
        Success = success;
        Message = message;
        Errors = errors;
    }

    public ApiResponse(bool success) : this(success, string.Empty)
    {
    }

    public ApiResponse(bool success, ICollection<string> errors) : this(success, string.Empty, errors)
    {
    }

    public ApiResponse(string message, ICollection<string> errors) : this(false, message, errors)
    {
    }

    public ApiResponse(string message) : this(false, message)
    {
    }

    public ApiResponse(ICollection<string> errors) : this(false, string.Empty, errors)
    {
    }
}
