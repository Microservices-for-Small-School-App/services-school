using School.Api.Endpoints;
using School.Api.Extensions;
using School.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add the Services
_ = builder.Services.ConfigureDependedServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

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
