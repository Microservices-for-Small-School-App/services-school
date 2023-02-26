using School.Api.Data.Dtos;

namespace School.Api.ApplicationCore.Interfaces;

public interface ICoursesBusiness
{
    Task<ApiResponseDto<IReadOnlyCollection<CourseDto>>> GetAllCourses();
}
