﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Data.Dtos;
using School.Api.Data.Entities;
using School.Api.Persistence;

namespace School.Api.Endpoints;

public static class CourseEndpoints
{

    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(CoursesRoutes.Prefix).WithTags(nameof(Course));

        _ = group.MapGet(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolDbContext, IMapper mapper) =>
        {
            var coursesResponse = ApiResponseDto<IReadOnlyCollection<CourseDto>>.Create(
                    mapper.Map<IReadOnlyCollection<CourseDto>>(await schoolDbContext.Courses.ToListAsync())
                );

            return Results.Ok(coursesResponse);
        })
          .AllowAnonymous()
          .WithName("GetAllCourses")
          .Produces<ApiResponseDto<IReadOnlyCollection<CourseDto>>>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status500InternalServerError)
          .WithOpenApi();

    }

}
