using System.ComponentModel.DataAnnotations;

namespace School.Api.Data.Entities;

public class Course : BaseEntity
{
    [Required]
    public Guid CourseId { get; set; }

    [Required]
    public string? Name { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }

    public string? PictureUrl { get; set; }
}
