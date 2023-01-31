using Microsoft.AspNetCore.Mvc;
using School.Api.Business;
using School.Api.Data.Dtos;
using static School.Api.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

# region Root & Hello World Endpoints
app.MapGet(HelloWorldEndpoints.Root, () => "Hello Minimal API World from Root !!");

app.MapGet(HelloWorldEndpoints.HelloWorld, () =>
{
    return ApiResponseDto<string>.Create("Hello Minimal API World from /hw !!");
});

app.MapGet(HelloWorldEndpoints.ApiUsers, ([FromRoute] string id, [FromQuery] string name) =>
{
    return ApiResponseDto<dynamic>.Create(new
    {
        UserId = id,
        Message = $"Hello {name}, Welcome to Minimal API World !!"
    });
});

app.MapGet(HelloWorldEndpoints.Api, DefaultResponseBusiness.SendDefaultApiEndpointOutput);

app.MapGet(HelloWorldEndpoints.ApiV1, () => DefaultResponseBusiness.SendDefaultApiEndpointV1Output());
#endregion

app.Run();



