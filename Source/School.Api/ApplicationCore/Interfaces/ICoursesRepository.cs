using School.Api.Data.Dtos;

namespace School.Api.ApplicationCore.Interfaces;

public interface ICoursesRepository
{
    Task<IReadOnlyCollection<CourseDto>> GetAllCourses();
}

