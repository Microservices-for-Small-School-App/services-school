using School.Api.ApplicationCore.Interfaces;
using School.Api.Data.Dtos;

namespace School.Api.Business;

public class CoursesBusiness : ICoursesBusiness
{
    private readonly ICoursesRepository _coursesRepository;
    private readonly ILogger<CoursesBusiness> _logger;

    public CoursesBusiness(ICoursesRepository coursesRepository, ILogger<CoursesBusiness> logger)
    {
        _coursesRepository = coursesRepository ?? throw new ArgumentNullException(nameof(coursesRepository));

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResponseDto<IReadOnlyCollection<CourseDto>>> GetAllCourses()
    {
        _logger.LogInformation($"Starting CoursesBusiness::GetAllCourses()");

        var courses = await _coursesRepository.GetAllCourses();

        return ApiResponseDto<IReadOnlyCollection<CourseDto>>.Create(courses);
    }

}
