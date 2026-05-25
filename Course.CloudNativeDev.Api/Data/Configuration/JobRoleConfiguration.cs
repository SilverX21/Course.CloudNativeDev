using Course.CloudNativeDev.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course.CloudNativeDev.Api.Data.Configuration;

public class JobRoleConfiguration : IEntityTypeConfiguration<JobRole>
{
    public void Configure(EntityTypeBuilder<JobRole> builder)
    {
        builder.HasData(
            new JobRole { Id = Guid.Parse("E51F98BB-D9EE-4496-B145-FB6891046F7D"), Name = "Manager" },
            new JobRole { Id = Guid.Parse("51BA96AA-167E-4CFF-BCA4-0C68F1555086"), Name = "Supervisor" },
            new JobRole { Id = Guid.Parse("51BA96AA-167E-4CFF-BCA4-0C68F1555034"), Name = "Sales" },
            new JobRole { Id = Guid.Parse("51BA96AA-167E-4CFF-BCA4-0C68F1655034"), Name = "Operations" }
        );
    }
}