namespace School.Api.Data.Entities
{

    public class Course : BaseEntity
    {
        public string? CourseId { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        public string? Description { get; set; }
    }

}
