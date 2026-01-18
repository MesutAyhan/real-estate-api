namespace RealEstateAPI.Business.DTOs.Common;

/// <summary>
/// API response için standart format
/// </summary>
public class ResponseDto<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ResponseDto<T> SuccessResult(T data, string message = "İşlem başarılı")
    {
        return new ResponseDto<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static ResponseDto<T> FailResult(string message, List<string>? errors = null)
    {
        return new ResponseDto<T>
        {
            Success = false,
            Message = message,
            Errors = errors
        };
    }
}