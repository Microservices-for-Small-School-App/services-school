using static Constants;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

# region Root & Hello World Endpoints
app.MapGet(HelloWorldEndpoints.Root, () => "Hello Minimal API World from Root !!");

app.MapGet(HelloWorldEndpoints.HelloWorld, () =>
{
    return ApiResponseDto<string>.Create("Hello Minimal API World from /hw !!");
});

app.MapGet(HelloWorldEndpoints.Api, DefaultResponseBusiness.SendDefaultApiEndpointOutput);

app.MapGet(HelloWorldEndpoints.ApiV1, () => DefaultResponseBusiness.SendDefaultApiEndpointV1Output());
#endregion

app.Run();

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

public static class DefaultResponseBusiness
{
    public static ApiResponseDto<string> SendDefaultApiEndpointOutput()
    {
        return ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint");
    }

    public static ApiResponseDto<string> SendDefaultApiEndpointV1Output()
    {
        return ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint V1");
    }

}

public static class Constants
{
    public static class HelloWorldEndpoints
    {
        public static string Root { get; } = "/";

        public static string HelloWorld { get; } = "/hw";

        public static string Api { get; } = "/api";

        public static string ApiV1 { get; } = "/api/v1";
    }

    public static class CoursesEndpoints
    {
        public static string Root { get; } = "/api/courses";

        public static string ActionById { get; } = "/api/courses/{Id}";
    }

    public static class StudentsEndpoints
    {
        public static string Root { get; } = "/api/students";

        public static string ActionById { get; } = "/api/students/{Id}";
    }
}