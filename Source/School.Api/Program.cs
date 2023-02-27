using School.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
_ = builder.Services.ConfigureDependedServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHttpRequestPipeline();

app.Run();
