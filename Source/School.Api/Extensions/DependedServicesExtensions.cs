using Microsoft.EntityFrameworkCore;
using School.Api.ApplicationCore.Interfaces;
using School.Api.Business;
using School.Api.Configurations;
using School.Api.Persistence;
using School.Api.Repositories;

namespace School.Api.Extensions;

public static class DependedServicesExtensions
{

    public static IServiceCollection ConfigureDependedServices(this IServiceCollection services)
    {
        _ = services.AddDbContext<SchoolDbContext>(options => options.UseInMemoryDatabase(InMemoryDatabase.Name));

        _ = services.AddAutoMapper(typeof(AutoMapperConfig));

        _ = services.AddScoped<ICoursesBusiness, CoursesBusiness>();

        _ = services.AddScoped<ICoursesRepository, CoursesRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        _ = services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        });

        return services;
    }
}
