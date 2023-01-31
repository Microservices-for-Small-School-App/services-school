using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Business;
using School.Api.Data.Dtos;
using School.Api.Data.Entities;
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

#region Courses Endpoints
app.MapGet(CoursesEndpoints.Root, async ([FromServices] SchoolDbContext schoolDbContext) =>
{
    return Results.Ok(await schoolDbContext.Courses.ToListAsync());
})
    .WithTags(nameof(Course))
    .WithName("GetAllCourses");
#endregion

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetService<SchoolDbContext>();
    _ = (context?.Database.EnsureCreated());
}

app.Run();



