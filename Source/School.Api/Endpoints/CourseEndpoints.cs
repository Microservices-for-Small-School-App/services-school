using Microsoft.AspNetCore.Mvc;
using School.Api.ApplicationCore.Interfaces;
using School.Api.Data.Dtos;
using School.Api.Data.Entities;

namespace School.Api.Endpoints;

public static class CourseEndpoints
{

    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(CoursesRoutes.Prefix).WithTags(nameof(Course));

        _ = group.MapGet(CoursesRoutes.Root, async ([FromServices] ICoursesBusiness coursesBusiness) =>
        {
            return Results.Ok(await coursesBusiness.GetAllCourses());
        })
          .AllowAnonymous()
          .WithName("GetAllCourses")
          .Produces<ApiResponseDto<IReadOnlyCollection<CourseDto>>>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status500InternalServerError)
          .WithOpenApi();

    }

}
