using Microsoft.AspNetCore.Mvc;
using School.Api.Data.Dtos;

namespace School.Api.Endpoints;

public static class UserEndpoints
{

    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(UsersRoutes.Prefix).WithTags(nameof(PersonDto));

        _ = group.MapGet(UsersRoutes.ActionById, ([FromRoute] string id, [FromQuery] string name) =>
        {
            return ApiResponseDto<dynamic>.Create(new
            {
                UserId = id,
                Message = $"Hello {name}, Welcome to Minimal API World !!"
            });
        });

        _ = group.MapPost(UsersRoutes.Root, ([FromBody] PersonDto person) =>
        {
            return ApiResponseDto<dynamic>.Create(new
            {
                UserId = person.Id,
                UserName = person.Name,
            });
        });

    }

}
