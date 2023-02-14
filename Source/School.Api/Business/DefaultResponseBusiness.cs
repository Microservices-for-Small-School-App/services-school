using School.Api.Data.Dtos;

namespace School.Api.Business;

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
