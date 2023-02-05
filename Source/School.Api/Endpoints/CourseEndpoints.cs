using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Data.Dtos;
using School.Api.Data.Entities;
using School.Api.Persistence;
// using static School.Api.ApplicationCore.Common.Constants;

namespace School.Api.Endpoints
{

    public static class CourseEndpoints
    {

        public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup(CoursesRoutes.Prefix).WithTags(nameof(Course));

            _ = group.MapGet(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolDbContext) =>
            {
                var coursesResponse = ApiResponseDto<IEnumerable<Course>>.Create(await schoolDbContext.Courses.ToListAsync());

                return Results.Ok(coursesResponse);
            });

        }

    }

}
