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
                    Title = "Minimal API Development",
                    Duration = 3,
                    Description = "C#",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "Admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "Admin"
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Title = "Ultimate API Development",
                    Duration = 5,
                    Description = "Blazor WASM",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "Admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "Admin"
                }
            );
        }

    }

}
