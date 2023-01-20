namespace School.Data.Dtos
{

    public record ApiResponseDto<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

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

}
