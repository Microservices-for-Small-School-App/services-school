using AutoMapper;
using School.Api.Data.Dtos;
using School.Api.Data.Entities;

namespace School.Api.Configurations;

public class AutoMapperConfig : Profile
{

    public AutoMapperConfig()
    {
        _ = CreateMap<Course, CourseDto>().ReverseMap();

        _ = CreateMap<Course, CreateCourseDto>().ReverseMap();
    }

}
