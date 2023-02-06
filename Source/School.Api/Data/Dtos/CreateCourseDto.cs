namespace School.Api.Data.Dtos
{

    public class CreateCourseDto
    {
        public Guid CourseId { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        public string? Description { get; set; }
    }

}
