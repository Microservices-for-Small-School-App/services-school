using Microsoft.EntityFrameworkCore;
using School.Api.Configurations;
using School.Api.Endpoints;
using School.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add the Services
_ = builder.Services.AddDbContext<SchoolDbContext>(options =>
                options.UseInMemoryDatabase(InMemoryDatabase.Name));

_ = builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen();

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
