using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Api.Data.Entities;

namespace School.Api.Persistence.SeedData
{

    internal class CourseData : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            _ = builder.HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    CourseId = Guid.NewGuid(),
                    Name = "Minimal API",
                    Duration = 3,
                    Description = "Minimal API for Beginners",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "Admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "Admin"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CourseId = Guid.NewGuid(),
                    Name = "Blazor WASM - Part 1",
                    Duration = 5,
                    Description = "Blazor WASM for Beginners",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "Admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "Admin"
                }
            );
        }

    }

}
