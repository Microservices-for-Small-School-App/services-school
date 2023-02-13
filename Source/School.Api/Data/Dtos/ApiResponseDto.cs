namespace School.Api.Data.Dtos;

public record ApiResponseDto<T>
{
    public bool Success { get; set; }

    public string? Message { get; set; }

    public DateTimeOffset DateRequested => DateTimeOffset.UtcNow;

    public T? Data { get; set; }

    public static ApiResponseDto<T> Create(T? data = default, string message = "Success", bool success = true)
    {
        return new()
        {
            Success = success,
            Message = message,
            Data = data
        };
    }
}
