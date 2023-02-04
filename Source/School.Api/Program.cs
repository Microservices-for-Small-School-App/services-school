using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Business;
using School.Api.Data.Dtos;
using School.Api.Persistence;
using static School.Api.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add the Services
_ = builder.Services.AddDbContext<SchoolDbContext>(options =>
                options.UseInMemoryDatabase(InMemoryDatabase.Name));

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

#region User Endpoints
app.MapGet(UsersEndpoints.ApiUsers, ([FromRoute] string id, [FromQuery] string name) =>
{
    return ApiResponseDto<dynamic>.Create(new
    {
        UserId = id,
        Message = $"Hello {name}, Welcome to Minimal API World !!"
    });
});

app.MapPost(UsersEndpoints.ApiPostUser, ([FromBody] PersonDto person) =>
{
    return ApiResponseDto<dynamic>.Create(new
    {
        UserId = person.Id,
        UserName = person.Name,
    });
});
#endregion

#region Courses Endpoints
app.MapGet(CoursesEndpoints.Root, async ([FromServices] SchoolDbContext schoolDbContext) =>
{
    return Results.Ok(await schoolDbContext.Courses.ToListAsync());
});
#endregion

if (app.Environment.IsDevelopment())
{
    // TODO: To be removed once we have .sqlproj
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetService<SchoolDbContext>();
    _ = (context?.Database.EnsureCreated());
}

app.Run();



//app.MapPost(HelloWorldEndpoints.ApiPostUser, ([FromBody] object personJson) =>
//{
//    var person = JsonConvert.DeserializeObject<dynamic>(personJson.ToString()!)!;
//    return ApiResponseDto<dynamic>.Create(new
//    {
//        UserId = $"{person.id}",
//        Message = $"Hello {person.name}, Welcome to Minimal API World !!"
//    });
//});