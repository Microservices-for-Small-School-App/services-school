using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Data.Dtos;
using School.Api.Data.Entities;
using School.Api.Endpoints;
using School.Api.Persistence;
using static School.Api.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add the Services
_ = builder.Services.AddDbContext<SchoolDbContext>(options =>
                options.UseInMemoryDatabase(InMemoryDatabase.Name));

var app = builder.Build();

#region Courses Endpoints
app.MapGet(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolDbContext) =>
{
    var coursesResponse = ApiResponseDto<IEnumerable<Course>>.Create(await schoolDbContext.Courses.ToListAsync());

    return Results.Ok(coursesResponse);
});
#endregion

if (app.Environment.IsDevelopment())
{
    // TODO: To be removed once we have .sqlproj
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetService<SchoolDbContext>();
    _ = (context?.Database.EnsureCreated());
}

// Endpoints
app.MapHelloWorldEndpoints();
app.MapUserEndpoints();

app.Run();
