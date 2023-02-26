using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Api.Data.Entities;

namespace School.Api.Persistence.SeedData;

internal class CourseData : IEntityTypeConfiguration<Course>
{

    public void Configure(EntityTypeBuilder<Course> builder)
    {
        _ = builder.HasData(
            new
            {
                Id = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                Name = "Web API in .NET 7",
                Duration = 3,
                Description = "Web API in .NET 7 for Beginners",
                PictureUrl = "https://stforeshop.blob.core.windows.net/coursesimages/WebAPIin_NET7.PNG",
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            },
            new
            {
                Id = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                Name = "Minimal API in .NET 7",
                Duration = 3,
                Description = "Minimal API in .NET 7 for Beginners",
                PictureUrl = "https://stforeshop.blob.core.windows.net/coursesimages/MinimalAPIin_NET7.PNG",
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            },
            new
            {
                Id = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                Name = "Blazor WASM in .NET 7",
                Duration = 5,
                Description = "Blazor WASM in .NET 7 for Beginners",
                PictureUrl = "https://stforeshop.blob.core.windows.net/coursesimages/BlazorWASMin_NET7.PNG",
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            },
            new
            {
                Id = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                Name = "gRPC in .NET 7",
                Duration = 5,
                Description = "gRPC in .NET 7 for Beginners",
                PictureUrl = "https://stforeshop.blob.core.windows.net/coursesimages/gRPCin_NET7.PNG",
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            },
            new
            {
                Id = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                Name = "App Services in Azure",
                Duration = 9,
                Description = "App Services in Azure for Beginners",
                PictureUrl = "https://stforeshop.blob.core.windows.net/coursesimages/AppServicesinAzure.PNG",
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            }
        );
    }

}
