using Microsoft.EntityFrameworkCore;
using School.Api.Endpoints;
using School.Api.Persistence;
using static School.Api.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add the Services
_ = builder.Services.AddDbContext<SchoolDbContext>(options =>
                options.UseInMemoryDatabase(InMemoryDatabase.Name));

var app = builder.Build();

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
app.MapCourseEndpoints();

app.Run();
