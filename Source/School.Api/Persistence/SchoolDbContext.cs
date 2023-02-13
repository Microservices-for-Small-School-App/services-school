using Microsoft.EntityFrameworkCore;
using School.Api.Data.Entities;
using School.Api.Persistence.SeedData;

namespace School.Api.Persistence;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CourseData());
    }
}
